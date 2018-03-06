CREATE PROCEDURE [dbo].[AccountType_Update]
    @Username [nvarchar](20),
    @Permission [nvarchar](128),
    @RoleName [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[AccountType]
    SET [RoleName] = @RoleName
    WHERE (([Username] = @Username) AND ([Permission] = @Permission))
END