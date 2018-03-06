CREATE PROCEDURE [dbo].[Cookie_Insert]
    @Domain [nvarchar](max),
    @DateCreatedSessionCookie [datetime],
    @ExpirationDate [datetime],
    @Path [nvarchar](max),
    @Email [nvarchar](128)
AS
BEGIN
    INSERT [dbo].[Cookie]([Domain], [DateCreatedSessionCookie], [ExpirationDate], [Path], [Email])
    VALUES (@Domain, @DateCreatedSessionCookie, @ExpirationDate, @Path, @Email)
    
    DECLARE @SessionID int
    SELECT @SessionID = [SessionID]
    FROM [dbo].[Cookie]
    WHERE @@ROWCOUNT > 0 AND [SessionID] = scope_identity()
    
    SELECT t0.[SessionID]
    FROM [dbo].[Cookie] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SessionID] = @SessionID
END