CREATE TABLE [dbo].[LinkedIn] (
    [UserName]      NVARCHAR (20)   NOT NULL,
    [AccessToken]   NVARCHAR (2000) NOT NULL,
    [TokenCreation] DATETIME        NOT NULL,
    CONSTRAINT [PK_dbo.LinkedIn] PRIMARY KEY CLUSTERED ([UserName] ASC, [AccessToken] ASC),
    CONSTRAINT [FK_dbo.LinkedIn_dbo.Account_UserName] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserName]
    ON [dbo].[LinkedIn]([UserName] ASC);

