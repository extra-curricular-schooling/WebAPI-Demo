CREATE TABLE [dbo].[User] (
    [Email]     NVARCHAR (128) NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Email] ASC)
);

