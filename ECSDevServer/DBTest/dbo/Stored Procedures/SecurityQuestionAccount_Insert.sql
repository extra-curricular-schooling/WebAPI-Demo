CREATE PROCEDURE [dbo].[SecurityQuestionAccount_Insert]
    @Username [nvarchar](20),
    @SecurityQuestionID [int],
    @Answer [nvarchar](100)
AS
BEGIN
    INSERT [dbo].[SecurityQuestionAccount]([SecurityQuestionID], [Username], [Answer])
    VALUES (@SecurityQuestionID, @Username, @Answer)
END