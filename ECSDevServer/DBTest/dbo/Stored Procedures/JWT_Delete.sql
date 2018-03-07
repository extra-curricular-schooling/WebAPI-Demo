CREATE PROCEDURE [dbo].[JWT_Delete]
    @JWTID [int]
AS
BEGIN
    DELETE [dbo].[JWT]
    WHERE ([JWTID] = @JWTID)
END