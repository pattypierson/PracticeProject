CREATE TABLE [dbo].[Team]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TeamName] NVARCHAR(50) NOT NULL, 
    [CreatedBy] NVARCHAR(128) NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getutcdate()
)
