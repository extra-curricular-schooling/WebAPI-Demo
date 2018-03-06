CREATE PROCEDURE [dbo].[LinkedIn_Update]
    @UserName [nvarchar](20),
    @AccessToken [nvarchar](2000),
    @TokenCreation [datetime]
AS
BEGIN
    UPDATE [dbo].[LinkedIn]
    SET [TokenCreation] = @TokenCreation
    WHERE (([UserName] = @UserName) AND ([AccessToken] = @AccessToken))
END