CREATE TABLE [dbo].[JWT] (
    [JWTID]      INT            IDENTITY (1, 1) NOT NULL,
    [Expiration] DATETIME       NOT NULL,
    [Issued]     NVARCHAR (MAX) NOT NULL,
    [Salt]       NVARCHAR (MAX) NOT NULL,
    [Email]      NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.JWT] PRIMARY KEY CLUSTERED ([JWTID] ASC),
    CONSTRAINT [FK_dbo.JWT_dbo.User_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[JWT]([Email] ASC);

