#! /usr/bin/env pwsh

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

$env:KIOTA_TUTORIAL_ENABLED = "false"

$OpenApiUrl = "https://raw.githubusercontent.com/martincostello/api/dotnet-nightly/src/API/wwwroot/swagger/api/openapi.json"

Push-Location ./KiotaExperiment

try {
    kiota generate `
        --language CSharp `
        --class-name ApiClient `
        --namespace-name KiotaExperiment.Client `
        --openapi $OpenApiUrl `
        --output ./Client `
        --additional-data false `
        --clean-output `
        --exclude-backward-compatible `
        --deserializer Microsoft.Kiota.Serialization.Json.JsonParseNodeFactory `
        --serializer Microsoft.Kiota.Serialization.Json.JsonSerializationWriterFactory `
        --structured-mime-types "application/json"

    if ($LASTEXITCODE -eq 0) {
        dotnet build
    }
} finally {
    Pop-Location
}
