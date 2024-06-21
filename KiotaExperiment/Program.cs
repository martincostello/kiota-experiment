using System.Globalization;
using System.Text.Json;
using System.Xml.Linq;
using KiotaExperiment.Client;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Shouldly;

var provider = new AnonymousAuthenticationProvider();
using var request = new HttpClientRequestAdapter(provider);

if (args.Length > 0)
{
    request.BaseUrl = args[0];
}

var client = new ApiClient(request);

try
{
    await CanGetTime(client);
    await CanGenerateGuid(client);
    await CanGenerateMachineKey(client);
    await CanGenerateHashes(client);
}
catch (Exception ex) when (ex is IParsable model)
{
    Console.WriteLine(await Serialize(model));
}

static async Task<string> Serialize<T>(T value)
    where T : IParsable
{
    var options = new JsonSerializerOptions() { WriteIndented = true };
    var json = await KiotaJsonSerializer.SerializeAsStringAsync(value);
    using var document = JsonSerializer.Deserialize<JsonDocument>(json, options);
    return JsonSerializer.Serialize(document, options);
}

static async Task CanGetTime(ApiClient client)
{
    // Arrange
    var tolerance = TimeSpan.FromSeconds(5);
    var utcNow = DateTimeOffset.UtcNow;

    // Act
    var response = await client.Time.GetAsync();

    // Assert
    response.ShouldNotBeNull();
    response.Timestamp.ShouldNotBeNull();
    response.Timestamp.Value.ShouldBe(utcNow, tolerance);

    DateTimeOffset.TryParse(response.Rfc1123, out var actual).ShouldBeTrue();
    actual.ShouldBe(utcNow, TimeSpan.FromSeconds(5), "rfc1123 is not a valid DateTimeOffset.");

    DateTimeOffset.TryParse(response.UniversalSortable, out actual).ShouldBeTrue();
    actual.ShouldBe(utcNow, TimeSpan.FromSeconds(5), "universalSortable is not a valid DateTimeOffset.");

    DateTimeOffset.TryParse(response.UniversalFull, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out actual).ShouldBeTrue();
    actual.ShouldBe(utcNow, TimeSpan.FromSeconds(5), "universalFull is not a valid DateTimeOffset.");

    response.Unix.ShouldNotBeNull();
    response.Unix.Value.ShouldBeGreaterThan(DateTimeOffset.UnixEpoch.ToUnixTimeSeconds());
    DateTimeOffset.FromUnixTimeSeconds(response.Unix.Value).ShouldBe(utcNow, TimeSpan.FromSeconds(5), "The value of unix is incorrect.");

    Console.WriteLine(await Serialize(response));
}

static async Task CanGenerateGuid(ApiClient client)
{
    // Act
    var response = await client.Tools.Guid.GetAsync();

    // Assert
    response.ShouldNotBeNull();
    response.Guid.ShouldNotBeNull();
    Guid.TryParse(response.Guid, out var actual).ShouldBeTrue();
    actual.ShouldNotBe(Guid.Empty);

    Console.WriteLine(await Serialize(response));
}

static async Task CanGenerateMachineKey(ApiClient client)
{
    // Act
    var response = await client.Tools.Machinekey.GetAsync((query) =>
    {
        query.QueryParameters.DecryptionAlgorithm = "AES-256";
        query.QueryParameters.ValidationAlgorithm = "SHA1";
    });

    // Assert
    response.ShouldNotBeNull();
    response.DecryptionKey.ShouldNotBeNullOrWhiteSpace();
    response.ValidationKey.ShouldNotBeNullOrWhiteSpace();
    response.MachineKeyXml.ShouldNotBeNullOrWhiteSpace();

    XElement.Parse(response.MachineKeyXml).ShouldNotBeNull();

    Console.WriteLine(await Serialize(response));
}

static async Task CanGenerateHashes(ApiClient client)
{
    (string algorithm, string format, string plaintext, string expected)[] testCases =
    [
        ("md5", "hexadecimal", "martincostello.com", "e6c3105bdb8e6466f9db1dab47a85131"),
        ("sha1", "hexadecimal", "martincostello.com", "7fbd8e8cf806e5282af895396f5268483bf6af1b"),
        ("sha256", "hexadecimal", "martincostello.com", "3b8143aa8119eaf0910aef5cade45dd0e6bb7b70e8d1c8c057bf3fc125248642"),
        ("sha384", "hexadecimal", "martincostello.com", "5c0e892a9348c184df255f46ab7282eb5792d552c896eb6893d90f36c7202540a9942c80ce5812616d29c08331c60510"),
        ("sha512", "hexadecimal", "martincostello.com", "3be0167275455dcf1e34f8818d48b7ae4a61fb8549153f42d0d035464fdccee97022d663549eb249d4796956e4016ad83d5e64ba766fb751c8fb2c03b2b4eb9a"),
    ];

    foreach ((var algorithm, var format, var plaintext, var expected) in testCases)
    {
        await CanGenerateHash(client, algorithm, format, plaintext, expected);
    }
}

static async Task CanGenerateHash(ApiClient client, string algorithm, string format, string plaintext, string expected)
{
    // Act
    var response = await client.Tools.Hash.PostAsync(new()
    {
        Algorithm = algorithm,
        Format = format,
        Plaintext = plaintext,
    });

    // Assert
    response.ShouldNotBeNull();
    response.Hash.ShouldBe(expected);

    Console.WriteLine(await Serialize(response));
}
