CREATE PROCEDURE [dbo].[Article_Delete]
    @ArticleLink [nvarchar](128),
    @InterestTag_TagName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[Article]
    WHERE (([ArticleLink] = @ArticleLink) AND (([InterestTag_TagName] = @InterestTag_TagName) OR ([InterestTag_TagName] IS NULL AND @InterestTag_TagName IS NULL)))
END