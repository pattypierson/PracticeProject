CREATE TABLE [dbo].[People]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleInitial] NCHAR(11) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ModifiedBy] NVARCHAR(128) NOT NULL
)
