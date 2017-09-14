CREATE PROCEDURE [dbo].[People_Delete]
	@Id int
AS
/*
DECLARE @_id int = 3
EXECUTE [dbo].[People_Delete] @_id
*/
BEGIN
	DELETE FROM [dbo].[People]
	WHERE Id = @Id
END
