CREATE PROCEDURE [dbo].[ZipLocation_Delete]
    @Email [nvarchar](128),
    @ZipCode [nvarchar](10)
AS
BEGIN
    DELETE [dbo].[ZipLocation]
    WHERE (([Email] = @Email) AND ([ZipCode] = @ZipCode))
END