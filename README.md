# ShopsRUs
A single service api for generating discounts, invoice and customers

# .Net SDK
- Download and istall the .NET SDK
  > https://dotnet.microsoft.com/download

# Visual Studio
- Simply open the solution file <code>ShopsRUs.sln</code> 
  > and wait for project restore. 
  > then build/run.

# Visual Studio Code
- After cloning 
  > run dotnet restore
  -  to restore all packages and dependencies
 
# Migration
- Run migration to gain access to the seeded data
- For Package Manager Console Visual Studio 
  > Update-Database
  
- For cmd/cli (Visual studio code)
  > dotnet ef database update
 
# Launch
- To launch the project
  > dotnet run (on the CLI or Package Manager Console)

# Testing
- To lunch the unit test project
  > dotnet test (on the CLI or Package Manager Console)