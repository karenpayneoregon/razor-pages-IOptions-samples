# About

This project reads settings from a SQL-Server database using EF Core and json columns. To get at the data, the EF Core DbContext reads the connection string from appsettings.json.

## SQL

Using the following statement to view data rather then seeing json in a regular SELECT.

```sql
SELECT ApplicationId,
       ApplicationName,
       ContactName,
       JSON_VALUE(MailSettings, '$.FromAddress') AS FromAddress,
       JSON_VALUE(MailSettings, '$.Host') AS Host,
       JSON_VALUE(GeneralSettings, '$.MainDatabaseConnection') AS Connection,
       JSON_VALUE(GeneralSettings, '$.ServicePath') AS [Service Path]
FROM dbo.Applications;
```
