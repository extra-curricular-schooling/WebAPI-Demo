CREATE PROCEDURE [dbo].[Cookie_Delete]
    @SessionID [int]
AS
BEGIN
    DELETE [dbo].[Cookie]
    WHERE ([SessionID] = @SessionID)
END