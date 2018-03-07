CREATE PROCEDURE [dbo].[JWT_Insert]
    @Token [nvarchar](max),
    @Email [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[JWT]([Token], [Email])
    VALUES (@Token, @Email)
    
    DECLARE @JWTID int
    SELECT @JWTID = [JWTID]
    FROM [dbo].[JWT]
    WHERE @@ROWCOUNT > 0 AND [JWTID] = scope_identity()
    
    SELECT t0.[JWTID]
    FROM [dbo].[JWT] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[JWTID] = @JWTID
END