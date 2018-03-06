CREATE PROCEDURE [dbo].[LinkedIn_Delete]
    @UserName [nvarchar](20),
    @AccessToken [nvarchar](2000)
AS
BEGIN
    DELETE [dbo].[LinkedIn]
    WHERE (([UserName] = @UserName) AND ([AccessToken] = @AccessToken))
END