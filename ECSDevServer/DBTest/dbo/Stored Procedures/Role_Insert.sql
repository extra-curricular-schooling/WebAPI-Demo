CREATE PROCEDURE [dbo].[Role_Insert]
    @RoleName [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Role]([RoleName])
    VALUES (@RoleName)
    
    DECLARE @RoleId int
    SELECT @RoleId = [RoleId]
    FROM [dbo].[Role]
    WHERE @@ROWCOUNT > 0 AND [RoleId] = scope_identity()
    
    SELECT t0.[RoleId]
    FROM [dbo].[Role] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[RoleId] = @RoleId
END