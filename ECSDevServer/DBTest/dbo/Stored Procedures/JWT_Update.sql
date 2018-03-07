CREATE PROCEDURE [dbo].[JWT_Update]
    @JWTID [int],
    @Token [nvarchar](max),
    @Email [nvarchar](128)
AS
BEGIN
    UPDATE [dbo].[JWT]
    SET [Token] = @Token, [Email] = @Email
    WHERE ([JWTID] = @JWTID)
END