# ASPNET-MVC-Log4Net-UI

----
## Setup
1. Run the CreateLogsTable.sql to create the database table

2. Install Log4Net and configure it to write logs to the database

    * https://www.nuget.org/packages/log4net/

3. Add LogsController.cs to the controller folder

    * Create a Logs folder under the Views folder
    * Add Index.cshtml and LogDetails.cshtml to the Logs folder under views

4. Update the datasource connection at the top of the LogsController as needed
