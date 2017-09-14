CREATE PROCEDURE [dbo].[People_Update]
	  @Id int
	, @FirstName nvarchar(50)
	, @MiddleInitial nchar(1) = null
	, @LastName nvarchar(50)
	, @ModifiedBy nvarchar(128)
AS
/*
DECLARE   
	  @_id INT = 1
	, @_firstName nvarchar(50) = 'Vic'
	, @_middleInitial nchar(1) = 'M'
	, @_lastName nvarchar(50) = 'Campos'
	, @_modifiedBy nvarchar(128) = 'Patty'

EXECUTE [dbo].[People_Update]
	  @_id, @_firstName, @_middleInitial, @_lastName, @_modifiedBy 

SELECT * FROM dbo.People WHERE Id = @_id;
*/
BEGIN
	DECLARE
		@ModifiedDate datetime2 = getutcdate()
	UPDATE [dbo].[People]
	SET 
		  FirstName = @FirstName
		, MiddleInitial = @MiddleInitial
		, LastName = @LastName
		, ModifiedDate = @ModifiedDate
		, ModifiedBy = @ModifiedBy
	WHERE Id = @Id
END
