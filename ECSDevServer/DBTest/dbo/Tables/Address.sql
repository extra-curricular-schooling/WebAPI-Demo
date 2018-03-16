CREATE TABLE [dbo].[Address] (
    [Email]     NVARCHAR (128) NOT NULL,
    [ZipCodeId] INT            NOT NULL,
    CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED ([Email] ASC, [ZipCodeId] ASC),
    CONSTRAINT [FK_dbo.Address_dbo.User_Email] FOREIGN KEY ([Email]) REFERENCES [dbo].[User] ([Email]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Address_dbo.ZipLocation_ZipCodeId] FOREIGN KEY ([ZipCodeId]) REFERENCES [dbo].[ZipLocation] ([ZipCodeId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ZipCodeId]
    ON [dbo].[Address]([ZipCodeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Email]
    ON [dbo].[Address]([Email] ASC);

