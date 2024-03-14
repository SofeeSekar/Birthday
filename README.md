# BithdayB
# Overview
This is a web application for creating a user and registering with birthday details.
The main focus of the application is  to show case the implementation of asp dotnet core 6 along with dependency injection

# Code Walkthrough
The code is divided into MVC model along with Factory design pattern. The code effective uses the dependcy injection for the services that are used in the code.

# Services
You could find the IWeaverservice and its corresponding implementatiohn in the Weaverservice api.
This api should define all the call that are get and post from the wearver api
The same is registered via dependency injection in the Program.cs

# CommonUtis
This folder contails all the common utilities that could be used in the appliation currently it has once utility for json conversion

# Db Context
The application uses Dbcontext to create tables and talk back and fro to the Pgadmin 
Postgres database is the DB backend used for the whole application.

# Important note

Please note to enable CORS policies for the application using the AddCors in the Program.cs
Configure you local port from asp dotnet in the NextJs application
