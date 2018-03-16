CREATE PROCEDURE [dbo].[ZipLocation_Delete]
    @ZipCodeId [int]
AS
BEGIN
    DELETE [dbo].[ZipLocation]
    WHERE ([ZipCodeId] = @ZipCodeId)
END