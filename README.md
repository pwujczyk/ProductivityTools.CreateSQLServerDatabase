<!--Category:Powershell--> 
 <p align="right">
    <a href="https://www.powershellgallery.com/packages/ProductivityTools.PSSetLockScreen/"><img src="Images/Header/Nuget_border_40px.png" /></a>
    <a href="http://www.productivitytools.tech/sql-commands/"><img src="Images/Header/ProductivityTools_green_40px_2.png" /><a> 
    <a href="https://www.github.com/pwujczyk/ProductivityTools.PSSetLockScreen"><img src="Images/Header/Github_border_40px.png" /></a>
</p>
<p align="center">
    <a href="https://www.powershellgallery.com/packages/ProductivityTools.PSSetLockScreen/">
        <img src="Images/Header/LogoTitle_green_500px.png" />
    </a>
</p>


# ProductivityTools.CreateSQLServerDatabase

Creates database on SQL Server. Used often before DBUp migrations.
<!--more-->

Library allow us to create database in simple two steps.
First we are creating Database object, providing target database name and the connection string. Next we can invoke three methods:

* Create – it creates database. If database exists throws exception
* CreateSilent – it creates database, but before creation it checks if database exists. When true do nothing.
* Exists – checks if database exists
Library removes from the connection string database name if provided. So from connection string:

```
"Server=.\\sql2019;Database=PTMeetings;Integrated Security=True"
````
Will use:

```
"Server=.\\sql2019;Integrated Security=True"
```

**Database** object implement **IDatabase** interface.

## Usage example:

```c#
Database database = new Database(name, "Server=.\\SQL2019;Trusted_Connection=True;");
database.Create();
```

![Create database](Images/CreateDatabase.png)
