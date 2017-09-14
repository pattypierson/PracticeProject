CREATE PROCEDURE [dbo].[People_SelectById]
	@Id int
AS
/*
	declare @_id int = 1
	exec [dbo].[people_selectbyid] @_id
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
	WHERE Id = @Id
END
