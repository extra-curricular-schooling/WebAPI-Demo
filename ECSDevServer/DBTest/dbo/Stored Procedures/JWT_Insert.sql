CREATE PROCEDURE [dbo].[JWT_Insert]
    @Expiration [datetime],
    @Issued [nvarchar](max),
    @Salt [nvarchar](max),
    @Email [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[JWT]([Expiration], [Issued], [Salt], [Email])
    VALUES (@Expiration, @Issued, @Salt, @Email)
    
    DECLARE @JWTID int
    SELECT @JWTID = [JWTID]
    FROM [dbo].[JWT]
    WHERE @@ROWCOUNT > 0 AND [JWTID] = scope_identity()
    
    SELECT t0.[JWTID]
    FROM [dbo].[JWT] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[JWTID] = @JWTID
END