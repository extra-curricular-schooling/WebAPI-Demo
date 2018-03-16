CREATE PROCEDURE [dbo].[ZipLocation_Update]
    @ZipCodeId [int],
    @ZipCode [nvarchar](10),
    @Address [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @Latitude [int],
    @Longitude [int]
AS
BEGIN
    UPDATE [dbo].[ZipLocation]
    SET [ZipCode] = @ZipCode, [Address] = @Address, [City] = @City, [State] = @State, [Latitude] = @Latitude, [Longitude] = @Longitude
    WHERE ([ZipCodeId] = @ZipCodeId)
END