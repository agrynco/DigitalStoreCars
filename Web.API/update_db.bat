@ECHO %1%
SETLOCAL
SET ASPNETCORE_ENVIRONMENT=%1%
dotnet ef database update --context CarsDbContext -p ../DAL.EF/DAL.EF.csproj
ENDLOCAL