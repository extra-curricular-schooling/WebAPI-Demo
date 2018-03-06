CREATE TABLE [dbo].[Account] (
    [UserName]       NVARCHAR (20)  NOT NULL,
    [Email]          NVARCHAR (128) NOT NULL,
    [Password]       NVARCHAR (20)  NOT NULL,
    [Points]         INT            NOT NULL,
    [AccountStatus]  BIT            NOT NULL,
    [SuspensionTime] DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Account] PRIMARY KEY CLUSTERED ([UserName] ASC),
    CONSTRAINT [FK_dbo.Account_dbo.User_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[Account]([Email] ASC);

