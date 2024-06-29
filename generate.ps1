#! /usr/bin/env pwsh

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

$env:KIOTA_TUTORIAL_ENABLED = "false"

$OpenApiUrl = "https://raw.githubusercontent.com/martincostello/api/dotnet-nightly/src/API/wwwroot/swagger/api/openapi.json"

Push-Location ./KiotaExperiment

try {
    kiota generate `
        --additional-data false `
        --class-name ApiClient `
        --clean-output `
        --deserializer Microsoft.Kiota.Serialization.Json.JsonParseNodeFactory `
        --exclude-backward-compatible `
        --language CSharp `
        --namespace-name KiotaExperiment.Client `
        --openapi $OpenApiUrl `
        --output ./Client `
        --serializer Microsoft.Kiota.Serialization.Json.JsonSerializationWriterFactory `
        --structured-mime-types "application/json"

    if ($LASTEXITCODE -eq 0) {
        dotnet build
    }
} finally {
    Pop-Location
}
