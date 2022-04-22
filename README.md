# ShopsRUs
A single service api for generating discounts, invoice and customers

# .Net SDK
- Download and istall the .NET SDK
  > https://dotnet.microsoft.com/download

# Configuration
- You should configure <code>appsettings.json</code> for Azure MSSQL connection string like;
  > Server=AZURE_SERVER_NAME; Initial Catalog=ShopRUs; Persist Security Info=False; User ID=SQL_USERNAME; Password=SQL_PASSWORD; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;

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
  > dotnet ef database update --project ShopsRUs.API
 
# Launch
- To launch the project
  > dotnet run --project ShopsRUs.API (on the CLI or Package Manager Console)

# Testing
- To lunch the unit test project
  > dotnet test (on the CLI or Package Manager Console)