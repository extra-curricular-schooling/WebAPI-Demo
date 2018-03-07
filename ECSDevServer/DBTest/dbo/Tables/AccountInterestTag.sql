CREATE TABLE [dbo].[AccountInterestTag] (
    [Account_UserName]    NVARCHAR (20)  NOT NULL,
    [InterestTag_TagName] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AccountInterestTag] PRIMARY KEY CLUSTERED ([Account_UserName] ASC, [InterestTag_TagName] ASC),
    CONSTRAINT [FK_dbo.AccountInterestTag_dbo.Account_Account_UserName] FOREIGN KEY ([Account_UserName]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AccountInterestTag_dbo.InterestTag_InterestTag_TagName] FOREIGN KEY ([InterestTag_TagName]) REFERENCES [dbo].[InterestTag] ([TagName]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_InterestTag_TagName]
    ON [dbo].[AccountInterestTag]([InterestTag_TagName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Account_UserName]
    ON [dbo].[AccountInterestTag]([Account_UserName] ASC);

