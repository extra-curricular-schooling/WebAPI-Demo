CREATE PROCEDURE [dbo].[AccountType_Delete]
    @Username [nvarchar](20),
    @Permission [nvarchar](128)
AS
BEGIN
    DELETE [dbo].[AccountType]
    WHERE (([Username] = @Username) AND ([Permission] = @Permission))
END