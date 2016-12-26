del src\TimeTable.Data\TimeTable.sqlite

cd src\TimeTable.DAL
rmdir Migrations /s /q

dotnet ef migrations add InitialCreate -c ApplicationDbContext
dotnet ef migrations add InitialCreate -c EntityDbContext

dotnet ef database update -c ApplicationDbContext
dotnet ef database update -c EntityDbContext

dotnet run init

pause
