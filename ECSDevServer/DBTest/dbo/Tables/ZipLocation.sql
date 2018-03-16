CREATE TABLE [dbo].[ZipLocation] (
    [ZipCodeId] INT            IDENTITY (1, 1) NOT NULL,
    [ZipCode]   NVARCHAR (10)  NOT NULL,
    [Address]   NVARCHAR (MAX) NOT NULL,
    [City]      NVARCHAR (MAX) NOT NULL,
    [State]     NVARCHAR (MAX) NOT NULL,
    [Latitude]  INT            NOT NULL,
    [Longitude] INT            NOT NULL,
    CONSTRAINT [PK_dbo.ZipLocation] PRIMARY KEY CLUSTERED ([ZipCodeId] ASC)
);






GO


