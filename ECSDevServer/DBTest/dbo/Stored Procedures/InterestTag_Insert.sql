CREATE PROCEDURE [dbo].[InterestTag_Insert]
    @TagName [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[InterestTag]([TagName])
    VALUES (@TagName)
END