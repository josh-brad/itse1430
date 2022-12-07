CREATE PROCEDURE [dbo].[FindByName]
	@name NVARCHAR(255)
AS BEGIN
    SET NOCOUNT ON;

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))

    SELECT *
    FROM Products
    WHERE Name = @name
END