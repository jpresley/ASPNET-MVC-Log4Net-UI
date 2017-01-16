# ASPNET-MVC-Log4Net-UI

----
## Setup
1. Run the CreateLogsTable.sql to create the database table

2. Install Log4Net and configure it to write logs to the database

    * https://www.nuget.org/packages/log4net/

3. Add Logs table to the EDMX file

4. Add LogsController.cs to the controller folder

    * Create a Logs folder under the Views folder
    * Add Index.cshtml and LogDetails.cshtml to the Logs folder under views

5. Update the model namespace at the top of the .cshtml files and the top of the controller

----
## Required CSS & JS
Add the following CSS and JS files to the view or shared layout

// ***** CSS Requirements ***** //

1. DataTables.NET

    <link href="//cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" rel="stylesheet" />

// ***** JS Requirements ***** //

1. jQuery

    <script src="https://code.jquery.com/jquery-1.12.4.min.js"></script>

2. jQuery UI

    <script src="http://code.jquery.com/ui/1.12.0/jquery-ui.min.js"></script>

3. jQuery Ajax Unobtrusive

	<script src="https://cdn.jsdelivr.net/jquery.ajax.unobtrusive/3.2.4/jquery.unobtrusive-ajax.min.js"></script>
	
4. DataTables.NET

	<script src="http://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
	
5. DataTables.NET Bootstrap

	<script src="https://cdn.datatables.net/1.10.13/js/dataTables.bootstrap.min.js"></script>
	
----
## Repository and Unit of Work
The UI is also set up to use the Repository and Unit of Work patterns

[Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application by Tom Dykstra] (https://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
