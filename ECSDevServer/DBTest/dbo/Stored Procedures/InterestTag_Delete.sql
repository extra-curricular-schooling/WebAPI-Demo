CREATE PROCEDURE [dbo].[InterestTag_Delete]
    @TagName [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[InterestTag]
    WHERE ([TagName] = @TagName)
END