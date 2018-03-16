CREATE PROCEDURE [dbo].[Role_Delete]
    @RoleId [int]
AS
BEGIN
    DELETE [dbo].[Role]
    WHERE ([RoleId] = @RoleId)
END