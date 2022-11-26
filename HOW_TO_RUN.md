# How to run Zap

1. Install MySQL Community Server. This must be installed on the same host as the web application will be running from.
   Also install MySQL Workbench.
2. Open MySQL Workbench and connect as the root user. Copy and paste the contents of the following file into the script window:
   [`src/Zap/SqlScripts/CreateDatabase.sql`](src/Zap/SqlScripts/CreateDatabase.sql).
   Run the entire script.
3. Install .NET 6. Go to [Microsoft's website](https://dotnet.microsoft.com/en-us/download) and download the .NET 6.0 SDK (not the .NET 7
   SDK, and not the hosting bundle or shared runtime).
4. Open a terminal and `cd` into the `src/Zap` subdirectory. Execute `dotnet run`. A Web browser window should
   appear containing the home page of the web application.
