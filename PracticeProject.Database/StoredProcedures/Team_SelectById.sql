CREATE PROCEDURE [dbo].[Team_SelectById]
	@Id int
AS
/*
	declare @_id int = 1
	exec [dbo].[team_selectbyid] @_id
*/
BEGIN
	SELECT 
		 [Id]
		,[TeamName]
		,[CreatedBy]
		,[CreatedDate]
		,[ModifiedDate]
	FROM [dbo].[Team]
	WHERE Id = @Id
END
