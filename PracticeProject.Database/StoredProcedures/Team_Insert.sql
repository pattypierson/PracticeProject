CREATE PROCEDURE [dbo].[Team_Insert]
	 @Id INT OUTPUT
	,@TeamName NVARCHAR(128)
	,@CreatedBy NVARCHAR(50)
AS
/*
DECLARE   
	  @_id INT = 0
	, @_teamName nvarchar(128) = 'Cool Kids'
	, @_createdBy nvarchar(50) = 'Patty'

EXECUTE [dbo].[Team_Insert]
	  @_id OUTPUT, @_teamName, @_createdBy

SELECT * FROM dbo.Team WHERE Id = @_id;
*/
BEGIN
	INSERT INTO [dbo].[Team]
		([TeamName]
		,[CreatedBy])
	VALUES
		(@TeamName
		,@CreatedBy)
	SET @Id = SCOPE_IDENTITY();
END
