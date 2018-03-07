CREATE TABLE [dbo].[JWT] (
    [JWTID] INT            IDENTITY (1, 1) NOT NULL,
    [Token] NVARCHAR (MAX) NULL,
    [Email] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.JWT] PRIMARY KEY CLUSTERED ([JWTID] ASC),
    CONSTRAINT [FK_dbo.JWT_dbo.User_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email])
);


GO
CREATE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[JWT]([Email] ASC);

