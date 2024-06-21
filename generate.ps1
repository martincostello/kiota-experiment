Push-Location ./KiotaExperiment
kiota generate -l CSharp -c ApiClient -n KiotaExperiment.Client -d ./openapi.json -o ./Client --co
Pop-Location
