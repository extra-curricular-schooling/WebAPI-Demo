CREATE TABLE [dbo].[ZipLocation] (
    [Email]     NVARCHAR (128) NOT NULL,
    [ZipCode]   NVARCHAR (10)  NOT NULL,
    [Address]   NVARCHAR (MAX) NOT NULL,
    [City]      NVARCHAR (MAX) NOT NULL,
    [State]     NVARCHAR (MAX) NOT NULL,
    [Latitude]  INT            NOT NULL,
    [Longitude] INT            NOT NULL,
    CONSTRAINT [PK_dbo.ZipLocation] PRIMARY KEY CLUSTERED ([Email] ASC, [ZipCode] ASC),
    CONSTRAINT [FK_dbo.ZipLocation_dbo.User_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[ZipLocation]([Email] ASC);

