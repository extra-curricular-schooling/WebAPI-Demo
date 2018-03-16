CREATE PROCEDURE [dbo].[Permission_Insert]
    @PermissionName [nvarchar](128),
    @RoleId [int]
AS
BEGIN
    INSERT [dbo].[Permission]([PermissionName], [RoleId])
    VALUES (@PermissionName, @RoleId)
END