CREATE PROCEDURE [dbo].[AccountType_Delete]
    @Username [nvarchar](20),
    @PermissionName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[AccountType]
    WHERE (([Username] = @Username) AND ([PermissionName] = @PermissionName))
END