CREATE PROCEDURE [dbo].[SecurityQuestionAccount_Update]
    @Username [nvarchar](20),
    @SecurityQuestionID [int],
    @Answer [nvarchar](100)
AS
BEGIN
    UPDATE [dbo].[SecurityQuestionAccount]
    SET [Answer] = @Answer
    WHERE (([SecurityQuestionID] = @SecurityQuestionID) AND ([Username] = @Username))
END