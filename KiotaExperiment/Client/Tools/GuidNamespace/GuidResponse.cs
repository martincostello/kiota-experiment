// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace KiotaExperiment.Client.Tools.GuidNamespace
{
    [Obsolete("This class is obsolete. Use GuidGetResponse instead.")]
    #pragma warning disable CS1591
    public class GuidResponse : KiotaExperiment.Client.Tools.GuidNamespace.GuidGetResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="KiotaExperiment.Client.Tools.GuidNamespace.GuidResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new KiotaExperiment.Client.Tools.GuidNamespace.GuidResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new KiotaExperiment.Client.Tools.GuidNamespace.GuidResponse();
        }
    }
}
