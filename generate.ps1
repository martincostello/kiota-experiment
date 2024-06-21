Push-Location ./KiotaExperiment

kiota generate `
    --language CSharp `
    --class-name ApiClient `
    --namespace-name KiotaExperiment.Client `
    --openapi ./openapi.json `
    --output ./Client `
    --clean-output `
    --exclude-backward-compatible

Pop-Location
