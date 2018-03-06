CREATE TABLE [dbo].[Article] (
    [ArticleLink]         NVARCHAR (128) NOT NULL,
    [ArticleTitle]        NVARCHAR (MAX) NOT NULL,
    [ArticleDescription]  NVARCHAR (MAX) NULL,
    [InterestTag_TagName] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Article] PRIMARY KEY CLUSTERED ([ArticleLink] ASC),
    CONSTRAINT [FK_dbo.Article_dbo.InterestTag_InterestTag_TagName] FOREIGN KEY ([InterestTag_TagName]) REFERENCES [dbo].[InterestTag] ([TagName])
);


GO
CREATE NONCLUSTERED INDEX [IX_InterestTag_TagName]
    ON [dbo].[Article]([InterestTag_TagName] ASC);

