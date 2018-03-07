CREATE TABLE [dbo].[AccountType] (
    [Username]   NVARCHAR (20)  NOT NULL,
    [Permission] NVARCHAR (128) NOT NULL,
    [RoleName]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.AccountType] PRIMARY KEY CLUSTERED ([Username] ASC, [Permission] ASC),
    CONSTRAINT [FK_dbo.AccountType_dbo.Account_Username] FOREIGN KEY ([Username]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Username]
    ON [dbo].[AccountType]([Username] ASC);

