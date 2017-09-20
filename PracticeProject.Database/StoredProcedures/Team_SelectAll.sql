CREATE PROCEDURE [dbo].[Team_SelectAll]
AS
/*
EXECUTE [dbo].[Team_SelectAll]
*/
BEGIN
	SELECT
		 [Id]
		,[TeamName]
		,[CreatedBy]
		,[CreatedDate]
		,[ModifiedDate]
	FROM
		[dbo].[Team]
END
