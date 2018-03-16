CREATE PROCEDURE [dbo].[AccountType_Insert]
    @Username [nvarchar](20),
    @PermissionName [nvarchar](128),
    @RoleId [int]
AS
BEGIN
    INSERT [dbo].[AccountType]([Username], [PermissionName], [RoleId])
    VALUES (@Username, @PermissionName, @RoleId)
END