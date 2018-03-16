CREATE PROCEDURE [dbo].[JWT_Update]
    @JWTID [int],
    @Expiration [DateTime],
	@Issued [nvarchar](max),
	@Salt [nvarchar](max),
    @Email [nvarchar](128)
AS
BEGIN
    UPDATE [dbo].[JWT]
    SET [Expiration] = @Expiration, [Issued] = @Issued, [Salt] = @Salt, [Email] = @Email
    WHERE ([JWTID] = @JWTID)
END