CREATE PROCEDURE [dbo].[SecurityQuestion_Delete]
    @SecurityQuestionID [int]
AS
BEGIN
    DELETE [dbo].[SecurityQuestion]
    WHERE ([SecurityQuestionID] = @SecurityQuestionID)
END