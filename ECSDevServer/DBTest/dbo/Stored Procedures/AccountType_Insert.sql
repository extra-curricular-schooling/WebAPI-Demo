CREATE PROCEDURE [dbo].[AccountType_Insert]
    @Username [nvarchar](20),
    @Permission [nvarchar](128),
    @RoleName [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[AccountType]([Username], [Permission], [RoleName])
    VALUES (@Username, @Permission, @RoleName)
END