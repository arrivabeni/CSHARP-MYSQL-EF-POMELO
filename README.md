# CSHARP_MYSQL_EF_POMELO
C# - Accessing MySQL using Entity Framework Core and Pomelo provider.

It is a simple sample to show how to use the Pomelo provider for .NET Entity Framework Core and access a MySQL database using the Database First approach. 

You can find more detailed information about Pomelo provider in its [oficial GitHub repository](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql).

### 1.Environment
Bellow you can find the entire used environment in this sample:

* Windows 10
* MySQL Community Version 5.7.23
* DotNet Core 2.1
* Visual Studio Code (not necessary to reproduce)

### 2.Database
As far as the Pomelo provider team recomends I suggest you to set the MySQL database default charset to __```utf8mb4```__. The following statement will check your DB charset:

```show variables like 'character_set_database';```

Otherwise if you have a fresh MySQL installation you will find a __```SampleDB.sql```__ file that provides you a really simple database schema to try the following code.

### 3.Creating C# Project
We are going to use Windows Powershell to create and adjust our C# project.

_You can access it typing __```powershell```__ in the Windows Run utility __```Win + r```___

The following commands will create a new C# project named as __```MyCSharpEfTest```__ and access its folder:

_Don't forget to access the folder where you want to generate you project before start._
```
dotnet new console -lang C# -f netcoreapp2 -o MyCSharpEfTest
cd MyCSharpEfTest
```

The following commands will access the .CSPROJ (__xml file__) and then change the target .NET framework and set a default namespace:
```
[xml]$csProjXML = Get-Content MyCSharpEfTest.csproj
$csProjXML.Project.PropertyGroup.TargetFramework = "netcoreapp2.1"
$child = $csProjXML.CreateElement("RootNamespace")
$csProjXML.Project.PropertyGroup.AppendChild($child)
$csProjXML.Project.PropertyGroup.RootNamespace = "com.mynamespace"
$csProjXML.Save((Get-Item -Path ".\").FullName + "\MyCSharpEfTest.csproj")
```

Now we are going to add the necessary libraries using the .NET command line utility:
```
dotnet add package Pomelo.EntityFrameworkCore.MySql -s https://www.myget.org/F/pomelo/api/v3/index.json -v 2.1.4
dotnet add package Microsoft.AspNetCore.App -v 2.1.4
dotnet restore
dotnet build
```

### 4.Scaffolding the database
Finally we are able to create the scaffold based on the database schema:

_Remember to change the uppercase placeholders by its correct data: __```SERVER_ADDRESS```__,__```DATABASE_NAME```__, __```DATABASE_USER```__ and __```USER_PASSWORD```___.
```
dotnet ef dbcontext scaffold "Server=SERVER_ADDRESS;Database=DATABASE_NAME;User=DATABASE_USER;Password=USER_PASSWORD;" "Pomelo.EntityFrameworkCore.MySql"
```
