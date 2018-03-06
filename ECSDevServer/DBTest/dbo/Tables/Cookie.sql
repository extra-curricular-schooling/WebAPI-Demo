CREATE TABLE [dbo].[Cookie] (
    [SessionID]                INT            IDENTITY (1, 1) NOT NULL,
    [Domain]                   NVARCHAR (MAX) NOT NULL,
    [DateCreatedSessionCookie] DATETIME       NOT NULL,
    [ExpirationDate]           DATETIME       NOT NULL,
    [Path]                     NVARCHAR (MAX) NULL,
    [Email]                    NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Cookie] PRIMARY KEY CLUSTERED ([SessionID] ASC),
    CONSTRAINT [FK_dbo.Cookie_dbo.User_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email])
);


GO
CREATE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[Cookie]([Email] ASC);

