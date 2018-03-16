CREATE PROCEDURE [dbo].[Salt_Update]
    @SaltId [int],
    @PasswordSalt [nvarchar](max),
    @UserName [nvarchar](20)
AS
BEGIN
    UPDATE [dbo].[Salt]
    SET [PasswordSalt] = @PasswordSalt, [UserName] = @UserName
    WHERE ([SaltId] = @SaltId)
END