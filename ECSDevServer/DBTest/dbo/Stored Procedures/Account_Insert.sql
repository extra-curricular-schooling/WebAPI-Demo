CREATE PROCEDURE [dbo].[Account_Insert]
    @UserName [nvarchar](20),
    @Email [nvarchar](128),
    @Password [nvarchar](20),
    @Points [int],
    @AccountStatus [bit],
    @SuspensionTime [datetime],
	@FirstTimeUser [bit]
AS
BEGIN
    INSERT [dbo].[Account]([UserName], [Email], [Password], [Points], [AccountStatus], [SuspensionTime], [FirstTimeUser])
    VALUES (@UserName, @Email, @Password, @Points, @AccountStatus, @SuspensionTime, @FirstTimeUser)
END