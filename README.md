**Hello there**

This is my Application developed as an Hotel Room's Availability and Managment Challenge.

For this, I created an default Database in a Local SQL Server connection called "Alten" with two entities.
    - Script for creating the tables are in the "scripts" folder;


**Bulding instructions**
    - Execute the script "CREATE_TABLES.sql" in the database of your choice;

    - Execute the script "INSERT_VALUES.sql" in the same database to create the room for our Hotel;
    
*Stay aware of the connectionString on the appsettings.json of the Alten.HotelChallenge.WebApi project*
    - If needed, change or update the connectionString and the "DatabaseName" to your database settings;

**Then, open the .sln file via Visual Studio and run "Alten.HotelChallenge.WebApi", or "dotnet run" in the WebApi folder via console.**
    - It will execute on "https://localhost:7245/swagger/index.html" or "http://localhost:5245/swagger/index.html";
    - To check the Health of the SQL Connection: Open "https://localhost:7245/health" or ""http://localhost:5245/health";


To make sure the API's conditions are working, I did some Unit Tests to check the functionality of the Input Validator using the Given-When-Then architecture.



    