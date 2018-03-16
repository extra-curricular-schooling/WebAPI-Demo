CREATE PROCEDURE [dbo].[Account_Update]
    @UserName [nvarchar](20),
    @Email [nvarchar](128),
    @Password [nvarchar](20),
    @Points [int],
    @AccountStatus [bit],
    @SuspensionTime [datetime],
    @FirstTimeUser [bit]
AS
BEGIN
    UPDATE [dbo].[Account]
    SET [Email] = @Email, [Password] = @Password, [Points] = @Points, [AccountStatus] = @AccountStatus, [SuspensionTime] = @SuspensionTime, [FirstTimeUser] = @FirstTimeUser
    WHERE ([UserName] = @UserName)
END