CREATE PROCEDURE [dbo].[AccountInterestTag_Delete]
    @Account_UserName [nvarchar](20),
    @InterestTag_TagName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[AccountInterestTag]
    WHERE (([Account_UserName] = @Account_UserName) AND ([InterestTag_TagName] = @InterestTag_TagName))
END