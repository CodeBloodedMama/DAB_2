# DAB_2
DAB HandIn2:
Municipality facilities database implemented with EFCore.

Participants:
Christina S. Købke
Marcin Szymanek
Elisbeth Lennert

SW4DAB@AU

# OBS
This project is configured to use SQL server with appsettings.js in project directory. To test the project locally you need to:
- setup your local SQL server in fx. Docker
- add your own appsettings.js with the following content:

{
    "ConnectionStrings" : {
        "MyConnString" : "Data Source=127.0.0.1,1433;Database=FacilitiesDb;User Id=sa;Password=<YourStrongPassword>;TrustServerCertificate=True"
    } 
}

and apply migrations via PackageManager/dotnet cli (update database)
