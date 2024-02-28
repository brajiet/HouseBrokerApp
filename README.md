# HouseBrokerApp
Steps For Running Application
1. Open Project in Visual Studion 2022
2. make changes to - Name of server, uid and password in appsettings.json as below
   "ConnectionStrings": {
   "HouseBrokerConnection": "Server=DESKTOP-HTR1JPK;database=HouseBroker_LIVE;uid=sa;password=manager@123;TrustServerCertificate=true;"
                       },
3. Open Package Manager Console from Tools>NuGet Package Manager
4. Set Default Project to- HouseBrokerApp.Data
5. then run, add-migration (migrationname)
6. then run, update-database
7. Open MSSQL Server there will be creations of different table in HouseBroker_LIVE Database
8. run this below scripts on database for roles
   GO
   INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Broker', N'Broker', NULL)
   GO
   INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'HouseSeeker', N'HouseSeeker', NULL)
   GO
9. Now run the application,It will open in Swagger
10. At first in Account Section , register the user
    email should be valid email, password must be at least 6 character including one capital letter and one number,
    set Isbroker ="true" for broker else false for normal user
11. Now confirm email with registered valid email
12. after successfull confirmation, go to login part of account section, provide registered email and password
   and will be login successfull, if as broker then as broker else as houseseeker
13. 

   
   
