CREATE TABLE [dbo].[Salt] (
    [SaltId]       INT            IDENTITY (1, 1) NOT NULL,
    [PasswordSalt] NVARCHAR (MAX) NOT NULL,
    [UserName]     NVARCHAR (20)  NOT NULL,
    CONSTRAINT [PK_dbo.Salt] PRIMARY KEY CLUSTERED ([SaltId] ASC),
    CONSTRAINT [FK_dbo.Salt_dbo.Account_UserName] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserName]
    ON [dbo].[Salt]([UserName] ASC);

