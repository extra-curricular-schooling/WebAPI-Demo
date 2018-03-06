CREATE PROCEDURE [dbo].[User_Update]
    @Email [nvarchar](128),
    @FirstName [nvarchar](50),
    @LastName [nvarchar](50)
AS
BEGIN
    UPDATE [dbo].[User]
    SET [FirstName] = @FirstName, [LastName] = @LastName
    WHERE ([Email] = @Email)
END