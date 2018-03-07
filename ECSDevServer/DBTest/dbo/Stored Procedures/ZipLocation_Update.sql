CREATE PROCEDURE [dbo].[ZipLocation_Update]
    @Email [nvarchar](128),
    @ZipCode [nvarchar](10),
    @Address [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @Latitude [int],
    @Longitude [int]
AS
BEGIN
    UPDATE [dbo].[ZipLocation]
    SET [Address] = @Address, [City] = @City, [State] = @State, [Latitude] = @Latitude, [Longitude] = @Longitude
    WHERE (([Email] = @Email) AND ([ZipCode] = @ZipCode))
END