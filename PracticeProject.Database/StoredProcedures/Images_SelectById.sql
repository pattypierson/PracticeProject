CREATE PROCEDURE [dbo].[Images_SelectById]
	@Id int
AS
/*
	declare @_id int = 1
	exec [dbo].[Images_SelectById] @_id
*/
BEGIN
	SELECT 
		 [Image]
	FROM [dbo].[Images]
	WHERE Id = @Id
END
