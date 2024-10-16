// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace KiotaExperiment.Client.Models
{
    /// <summary>
    /// Represents the response from the /tools/machinekey API resource.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class MachineKeyResponse : IParsable
    {
        /// <summary>A string containing the decryption key.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DecryptionKey { get; set; }
#nullable restore
#else
        public string DecryptionKey { get; set; }
#endif
        /// <summary>A string containing the machineKey XML configuration element.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? MachineKeyXml { get; set; }
#nullable restore
#else
        public string MachineKeyXml { get; set; }
#endif
        /// <summary>A string containing the validation key.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ValidationKey { get; set; }
#nullable restore
#else
        public string ValidationKey { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::KiotaExperiment.Client.Models.MachineKeyResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::KiotaExperiment.Client.Models.MachineKeyResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::KiotaExperiment.Client.Models.MachineKeyResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "decryptionKey", n => { DecryptionKey = n.GetStringValue(); } },
                { "machineKeyXml", n => { MachineKeyXml = n.GetStringValue(); } },
                { "validationKey", n => { ValidationKey = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("decryptionKey", DecryptionKey);
            writer.WriteStringValue("machineKeyXml", MachineKeyXml);
            writer.WriteStringValue("validationKey", ValidationKey);
        }
    }
}
#pragma warning restore CS0618
