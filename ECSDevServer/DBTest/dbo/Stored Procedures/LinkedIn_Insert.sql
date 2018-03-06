CREATE PROCEDURE [dbo].[LinkedIn_Insert]
    @UserName [nvarchar](20),
    @AccessToken [nvarchar](2000),
    @TokenCreation [datetime]
AS
BEGIN
    INSERT [dbo].[LinkedIn]([UserName], [AccessToken], [TokenCreation])
    VALUES (@UserName, @AccessToken, @TokenCreation)
END