SELECT ApplicationId,
       ApplicationName,
       ContactName,
       JSON_VALUE(MailSettings, '$.FromAddress') AS FromAddress,
       JSON_VALUE(MailSettings, '$.Host') AS Host,
       JSON_VALUE(GeneralSettings, '$.MainDatabaseConnection') AS Connection,
       JSON_VALUE(GeneralSettings, '$.ServicePath') AS [Service Path]
FROM dbo.Applications;