CREATE PROCEDURE [dbo].[Salt_Insert]
    @PasswordSalt [nvarchar](max),
    @UserName [nvarchar](20)
AS
BEGIN
    INSERT [dbo].[Salt]([PasswordSalt], [UserName])
    VALUES (@PasswordSalt, @UserName)
    
    DECLARE @SaltId int
    SELECT @SaltId = [SaltId]
    FROM [dbo].[Salt]
    WHERE @@ROWCOUNT > 0 AND [SaltId] = scope_identity()
    
    SELECT t0.[SaltId]
    FROM [dbo].[Salt] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SaltId] = @SaltId
END