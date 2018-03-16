CREATE PROCEDURE [dbo].[ZipLocation_Insert]
    @ZipCode [nvarchar](10),
    @Address [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @Latitude [int],
    @Longitude [int]
AS
BEGIN
    INSERT [dbo].[ZipLocation]([ZipCode], [Address], [City], [State], [Latitude], [Longitude])
    VALUES (@ZipCode, @Address, @City, @State, @Latitude, @Longitude)
    
    DECLARE @ZipCodeId int
    SELECT @ZipCodeId = [ZipCodeId]
    FROM [dbo].[ZipLocation]
    WHERE @@ROWCOUNT > 0 AND [ZipCodeId] = scope_identity()
    
    SELECT t0.[ZipCodeId]
    FROM [dbo].[ZipLocation] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[ZipCodeId] = @ZipCodeId
END