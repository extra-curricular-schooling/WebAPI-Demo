CREATE PROCEDURE [dbo].[Role_Update]
    @RoleId [int],
    @RoleName [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Role]
    SET [RoleName] = @RoleName
    WHERE ([RoleId] = @RoleId)
END