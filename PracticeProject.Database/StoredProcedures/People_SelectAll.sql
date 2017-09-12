CREATE PROCEDURE [dbo].[People_SelectAll]
AS
/*
EXECUTE [dbo].[People_SelectAll]
*/
BEGIN
	SELECT 
		 [Id]
		,[FirstName]
		,[MiddleInitial]
		,[LastName]
		,[CreatedDate]
		,[ModifiedDate]
		,[ModifiedBy]
	FROM [dbo].[People]
END
