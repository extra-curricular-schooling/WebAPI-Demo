CREATE PROCEDURE [dbo].[AccountType_Update]
    @Username [nvarchar](20),
    @PermissionName [nvarchar](128),
    @RoleId [int]
AS
BEGIN
    UPDATE [dbo].[AccountType]
    SET [RoleId] = @RoleId
    WHERE (([Username] = @Username) AND ([PermissionName] = @PermissionName))
END