CREATE PROCEDURE [dbo].[Permission_Delete]
    @PermissionName [nvarchar](128),
    @RoleId [int]
AS
BEGIN
    DELETE [dbo].[Permission]
    WHERE (([PermissionName] = @PermissionName) AND ([RoleId] = @RoleId))
END