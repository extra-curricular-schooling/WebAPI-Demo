CREATE PROCEDURE [dbo].[Article_Update]
    @ArticleLink [nvarchar](128),
    @ArticleTitle [nvarchar](max),
    @ArticleDescription [nvarchar](max),
    @InterestTag_TagName [nvarchar](128)
AS
BEGIN
    UPDATE [dbo].[Article]
    SET [ArticleTitle] = @ArticleTitle, [ArticleDescription] = @ArticleDescription, [InterestTag_TagName] = @InterestTag_TagName
    WHERE ([ArticleLink] = @ArticleLink)
END