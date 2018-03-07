CREATE PROCEDURE [dbo].[SecurityQuestionAccount_Delete]
    @Username [nvarchar](20),
    @SecurityQuestionID [int]
AS
BEGIN
    DELETE [dbo].[SecurityQuestionAccount]
    WHERE (([SecurityQuestionID] = @SecurityQuestionID) AND ([Username] = @Username))
END