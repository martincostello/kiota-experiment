// <auto-generated/>
using KiotaExperiment.Client.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace KiotaExperiment.Client.Tools.Machinekey
{
    /// <summary>
    /// Builds and executes requests for operations under \tools\machinekey
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class MachinekeyRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MachinekeyRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/tools/machinekey{?decryptionAlgorithm*,validationAlgorithm*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public MachinekeyRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/tools/machinekey{?decryptionAlgorithm*,validationAlgorithm*}", rawUrl)
        {
        }
        /// <summary>
        /// Generates a machine key for a Web.config configuration file for ASP.NET.
        /// </summary>
        /// <returns>A <see cref="global::KiotaExperiment.Client.Models.MachineKeyResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::KiotaExperiment.Client.Models.ProblemDetails">When receiving a 400 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::KiotaExperiment.Client.Models.MachineKeyResponse?> GetAsync(Action<RequestConfiguration<global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder.MachinekeyRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::KiotaExperiment.Client.Models.MachineKeyResponse> GetAsync(Action<RequestConfiguration<global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder.MachinekeyRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::KiotaExperiment.Client.Models.ProblemDetails.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::KiotaExperiment.Client.Models.MachineKeyResponse>(requestInfo, global::KiotaExperiment.Client.Models.MachineKeyResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Generates a machine key for a Web.config configuration file for ASP.NET.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder.MachinekeyRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder.MachinekeyRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder WithUrl(string rawUrl)
        {
            return new global::KiotaExperiment.Client.Tools.Machinekey.MachinekeyRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Generates a machine key for a Web.config configuration file for ASP.NET.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
        public partial class MachinekeyRequestBuilderGetQueryParameters 
        {
            /// <summary>The name of the decryption algorithm.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("decryptionAlgorithm")]
            public string? DecryptionAlgorithm { get; set; }
#nullable restore
#else
            [QueryParameter("decryptionAlgorithm")]
            public string DecryptionAlgorithm { get; set; }
#endif
            /// <summary>The name of the validation algorithm.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("validationAlgorithm")]
            public string? ValidationAlgorithm { get; set; }
#nullable restore
#else
            [QueryParameter("validationAlgorithm")]
            public string ValidationAlgorithm { get; set; }
#endif
        }
    }
}
