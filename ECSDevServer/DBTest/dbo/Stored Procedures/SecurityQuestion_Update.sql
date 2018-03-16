CREATE PROCEDURE [dbo].[SecurityQuestion_Update]
    @SecurityQuestionID [int],
    @SecQuestion [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[SecurityQuestion]
    SET [SecQuestion] = @SecQuestion
    WHERE ([SecurityQuestionID] = @SecurityQuestionID)
END