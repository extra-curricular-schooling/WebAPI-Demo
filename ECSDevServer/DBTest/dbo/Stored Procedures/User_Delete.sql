CREATE PROCEDURE [dbo].[User_Delete]
    @Email [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[User]
    WHERE ([Email] = @Email)
END