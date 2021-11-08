IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Security')
BEGIN
    CREATE DATABASE [Security]
END
GO

IF NOT EXISTS(SELECT name  
     FROM master.sys.server_principals
     WHERE name = '--ServiceUsername--')
BEGIN
    CREATE LOGIN [--ServiceUsername--] WITH PASSWORD = '--ServicePassword--'
END
GO

USE [Security]

    IF NOT EXISTS 
        (SELECT name  
        FROM sys.database_principals
        WHERE name = '--ServiceUsername--')
    BEGIN
        CREATE USER [--ServiceUsername--] FOR LOGIN [--ServiceUsername--]

    END

GO

EXECUTE sp_addrolemember N'db_datareader', N'--ServiceUsername--'
EXECUTE sp_addrolemember N'db_datawriter', N'--ServiceUsername--'

