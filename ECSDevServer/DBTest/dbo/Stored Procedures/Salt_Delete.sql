CREATE PROCEDURE [dbo].[Salt_Delete]
    @SaltId [int]
AS
BEGIN
    DELETE [dbo].[Salt]
    WHERE ([SaltId] = @SaltId)
END