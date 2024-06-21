using System.Text.Json;
using KiotaExperiment.Client;
using KiotaExperiment.Client.Models;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Http.HttpClientLibrary;

JsonSerializerOptions options = new() { WriteIndented = true };

var provider = new AnonymousAuthenticationProvider();
using var request = new HttpClientRequestAdapter(provider);

if (args.Length > 0)
{
    request.BaseUrl = args[0];
}

var client = new ApiClient(request);

try
{
    var time = await client.Time.GetAsync();
    Console.WriteLine(await Serialize(time, options));

    var guid = await client.Tools.Guid.GetAsync();
    Console.WriteLine(await Serialize(guid, options));

    var key = await client.Tools.Machinekey.GetAsync((query) =>
    {
        query.QueryParameters.DecryptionAlgorithm = "AES-256";
        query.QueryParameters.ValidationAlgorithm = "SHA1";
    });
    Console.WriteLine(await Serialize(key, options));

    var hash = await client.Tools.Hash.PostAsync(new()
    {
        Algorithm = "sha1",
        Format = "hexadecimal",
        Plaintext = "martincostello.com",
    });
    Console.WriteLine(await Serialize(hash, options));
}
catch (ProblemDetails ex)
{
    Console.WriteLine(await Serialize(ex, options));
}

static async Task<string> Serialize<T>(T? value, JsonSerializerOptions options)
    where T : IParsable
{
    var json = await KiotaJsonSerializer.SerializeAsStringAsync(value!);
    using var document = JsonSerializer.Deserialize<JsonDocument>(json, options);
    return JsonSerializer.Serialize(document, options);
}
