CREATE PROCEDURE [dbo].[Images_Insert]
	  @Id int output
	, @ImageName nvarchar(50)
	, @Image nvarchar(256) = null
	
AS
/*
DECLARE   
	  @_id INT = 0
	, @_imageName nvarchar(50) = 'test'
	, @_image nvarchar(256) = 'test'	

EXECUTE [dbo].[Images_Insert]
	  @_id OUTPUT, @_imageName, @_image

SELECT * FROM dbo.Images WHERE Id = @_id;
*/
BEGIN
	INSERT INTO [dbo].[Images]
		([ImageName]
		,[Image])
		
	VALUES
		(@ImageName
		,@Image)
	SET @Id = SCOPE_IDENTITY();
END

