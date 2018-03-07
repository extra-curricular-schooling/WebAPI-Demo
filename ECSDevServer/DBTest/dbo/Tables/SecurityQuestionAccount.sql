CREATE TABLE [dbo].[SecurityQuestionAccount] (
    [SecurityQuestionID] INT            NOT NULL,
    [Username]           NVARCHAR (20)  NOT NULL,
    [Answer]             NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_dbo.SecurityQuestionAccount] PRIMARY KEY CLUSTERED ([SecurityQuestionID] ASC, [Username] ASC),
    CONSTRAINT [FK_dbo.SecurityQuestionAccount_dbo.Account_Username] FOREIGN KEY ([Username]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.SecurityQuestionAccount_dbo.SecurityQuestion_SecurityQuestionID] FOREIGN KEY ([SecurityQuestionID]) REFERENCES [dbo].[SecurityQuestion] ([SecurityQuestionID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SecurityQuestionID]
    ON [dbo].[SecurityQuestionAccount]([SecurityQuestionID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Username]
    ON [dbo].[SecurityQuestionAccount]([Username] ASC);

