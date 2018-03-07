CREATE PROCEDURE [dbo].[SecurityQuestion_Update]
    @SecurityQuestionID [int],
    @SecurityQuestions [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[SecurityQuestion]
    SET [SecurityQuestions] = @SecurityQuestions
    WHERE ([SecurityQuestionID] = @SecurityQuestionID)
END