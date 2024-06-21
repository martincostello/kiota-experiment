#! /usr/bin/env pwsh

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

Push-Location ./KiotaExperiment

try {
    kiota generate `
        --language CSharp `
        --class-name ApiClient `
        --namespace-name KiotaExperiment.Client `
        --openapi ./openapi.json `
        --output ./Client `
        --clean-output `
        --exclude-backward-compatible `
        --deserializer Microsoft.Kiota.Serialization.Json.JsonParseNodeFactory `
        --serializer Microsoft.Kiota.Serialization.Json.JsonSerializationWriterFactory

    if ($LASTEXITCODE -eq 0) {
        dotnet build
    }
} finally {
    Pop-Location
}
