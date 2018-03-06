CREATE PROCEDURE [dbo].[Account_Delete]
    @UserName [nvarchar](20)
AS
BEGIN
    DELETE [dbo].[Account]
    WHERE ([UserName] = @UserName)
END