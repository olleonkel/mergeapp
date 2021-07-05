## app description

The app retrieves a list of intervals in json format and returns a / a list of non-overlapping and merged overlapping intervals.


## installation instructions

### option: run with <code>dotnet</code> cli

+ install .Net 5.x SDK on your system, see:https://dotnet.microsoft.com/download
+ clone repository and checkout tag <code>0.1.0</code>
+ <code>cd MergeApp/MergeApp</code>
+ run <code>dotnet restore</code>
+ run <code>dotnet run</code>
+ run example with the provided <code>testintervals.json</code>: <code> curl -H "Content-Type: application/json" -d @testintervals.json http://localhost:5000/merge/ -v</code> or check the Swagger-UI under https://localhost:5000/swagger

### option: run as container with Docker or Podman

+ clone repository and checkout tag <code>0.1.0</code>
+ run: <code>docker/podman build MergeApp -t mergeapp:0.1.0</code>
+ run image with: <code>docker/podman run -p 8080:80 mergeapp:0.1.0</code>
+ run example with the provided <code>testintervals.json</code>: <code> curl -H "Content-Type: application/json" -d @testintervals.json http://localhost:8080/merge/ -v</code>
