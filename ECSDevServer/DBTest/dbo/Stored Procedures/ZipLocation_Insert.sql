CREATE PROCEDURE [dbo].[ZipLocation_Insert]
    @Email [nvarchar](128),
    @ZipCode [nvarchar](10),
    @Address [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @Latitude [int],
    @Longitude [int]
AS
BEGIN
    INSERT [dbo].[ZipLocation]([Email], [ZipCode], [Address], [City], [State], [Latitude], [Longitude])
    VALUES (@Email, @ZipCode, @Address, @City, @State, @Latitude, @Longitude)
END