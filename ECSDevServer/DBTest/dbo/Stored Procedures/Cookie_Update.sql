CREATE PROCEDURE [dbo].[Cookie_Update]
    @SessionID [int],
    @Domain [nvarchar](max),
    @DateCreatedSessionCookie [datetime],
    @ExpirationDate [datetime],
    @Path [nvarchar](max),
    @Email [nvarchar](128)
AS
BEGIN
    UPDATE [dbo].[Cookie]
    SET [Domain] = @Domain, [DateCreatedSessionCookie] = @DateCreatedSessionCookie, [ExpirationDate] = @ExpirationDate, [Path] = @Path, [Email] = @Email
    WHERE ([SessionID] = @SessionID)
END