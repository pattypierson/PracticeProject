CREATE PROCEDURE [dbo].[Team_Update]
	 @Id INT OUTPUT
	,@TeamName NVARCHAR(128)
	,@CreatedBy NVARCHAR(50)
AS
/*
DECLARE   
	  @_id INT = 0
	, @_teamName nvarchar(128) = 'Cool Kids'
	, @_createdBy nvarchar(50) = 'Patty'

EXECUTE [dbo].[Team_Update]
	  @_id, @_teamName, @_createdBy

SELECT * FROM dbo.Team WHERE Id = @_id;
*/
BEGIN
	DECLARE @ModifiedDate DATETIME2(7) = getutcdate()
	UPDATE [dbo].[Team]
	SET
		 [TeamName] = @TeamName
		,[CreatedBy] = @CreatedBy
		,[ModifiedDate] = @ModifiedDate
	WHERE
		Id = @Id
END
