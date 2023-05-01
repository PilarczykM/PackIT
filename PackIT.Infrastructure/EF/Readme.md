# Run migration

Windows:
dotnet ef migrations add {NAME} --context ReadDbContext --startup-project ..\PackIT.Api\ -o .\EF\Migrations

Linux / Mac:
dotnet ef migrations add {NAME} --context ReadDbContext --startup-project ../PackIT.Api/ -o ./EF/Migrations

where {NAME} is simple string coresponding to name of migration.

If you do not have dotnet global ef just run:

* dotnet tool install --global dotnet-ef
