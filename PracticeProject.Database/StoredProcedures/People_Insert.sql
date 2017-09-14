CREATE PROCEDURE [dbo].[People_Insert]
	  @Id int output
	, @FirstName nvarchar(50)
	, @MiddleInitial nchar(1) = null
	, @LastName nvarchar(50)
	, @ModifiedBy nvarchar(128)
AS
/*
DECLARE   
	  @_id INT = 0
	, @_firstName nvarchar(50) = 'Austin'
	, @_middleInitial nchar(1) = 'J'
	, @_lastName nvarchar(50) = 'Overholt'
	, @_modifiedBy nvarchar(128) = 'Admin'

EXECUTE [dbo].[People_Insert]
	  @_id OUTPUT, @_firstName, @_middleInitial, @_lastName, @_modifiedBy 

SELECT * FROM dbo.People WHERE Id = @_id;
*/
BEGIN
	INSERT INTO [dbo].[People]
		([FirstName]
		,[MiddleInitial]
		,[LastName]
		,[ModifiedBy])
	VALUES
		(@FirstName
		,@MiddleInitial
		,@LastName
		,@ModifiedBy)
	SET @Id = SCOPE_IDENTITY();
END
