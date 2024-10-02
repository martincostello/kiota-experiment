#! /usr/bin/env pwsh

param(
    [Parameter(Mandatory = $false)][string] $OpenApiUrl = "https://api.martincostello.com/openapi/api.json",
    [Parameter(Mandatory = $false)][switch] $Regenerate
)

$ErrorActionPreference = "Stop"
$ProgressPreference = "SilentlyContinue"

$env:KIOTA_TUTORIAL_ENABLED = "false"

$OutputPath = "./Client"

Push-Location ./KiotaExperiment

try {
    if ($Regenerate) {
        kiota generate `
            --additional-data false `
            --class-name ApiClient `
            --clean-output `
            --deserializer Microsoft.Kiota.Serialization.Json.JsonParseNodeFactory `
            --exclude-backward-compatible `
            --language CSharp `
            --namespace-name KiotaExperiment.Client `
            --openapi $OpenApiUrl `
            --output $OutputPath `
            --serializer Microsoft.Kiota.Serialization.Json.JsonSerializationWriterFactory `
            --structured-mime-types "application/json"
    } else {
        kiota update --clean-output --output $OutputPath
    }

    if ($LASTEXITCODE -eq 0) {
        dotnet build
    }
} finally {
    Pop-Location
}
