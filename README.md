# ProductivityTools.CreateSQLServerDatabase

Library is responsible for creating database on SQL Server. 

To use it please create new instance of **Database** object providing connection string.
Connection string can be with or without database name. 

``Database database = new Database(name, "Server=.\\SQL2017;Trusted_Connection=True;");``

``Database database = new Database(name, $"Server=.\\SQL2017;Database={name};Trusted_Connection=True;");``

If we provide database name in the connection string it will be ignored during creation, and first parameter will be taken. 

Library has three methods:
- Create - create database, throws exception if database exists
- Exists - check if database exists
- CreateSilent - check if database exists and create if not. Doesn't throw exception.

**Database** object implement **IDatabase** interface.

## Usage example:

```c#
Database database = new Database(name, "Server=.\\SQL2017;Trusted_Connection=True;");
database.Create();
```