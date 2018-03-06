CREATE PROCEDURE [dbo].[Article_Insert]
    @ArticleLink [nvarchar](128),
    @ArticleTitle [nvarchar](max),
    @ArticleDescription [nvarchar](max),
    @tag_name [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[Article]([ArticleLink], [ArticleTitle], [ArticleDescription], [InterestTag_TagName])
    VALUES (@ArticleLink, @ArticleTitle, @ArticleDescription, @tag_name)
END