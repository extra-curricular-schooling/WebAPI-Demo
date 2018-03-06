CREATE PROCEDURE [dbo].[AccountInterestTag_Insert]
    @Account_UserName [nvarchar](20),
    @InterestTag_TagName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[AccountInterestTag]([Account_UserName], [InterestTag_TagName])
    VALUES (@Account_UserName, @InterestTag_TagName)
END