CREATE PROCEDURE [dbo].[SecurityQuestion_Insert]
    @SecQuestion [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[SecurityQuestion]([SecQuestion])
    VALUES (@SecQuestion)
    
    DECLARE @SecurityQuestionID int
    SELECT @SecurityQuestionID = [SecurityQuestionID]
    FROM [dbo].[SecurityQuestion]
    WHERE @@ROWCOUNT > 0 AND [SecurityQuestionID] = scope_identity()
    
    SELECT t0.[SecurityQuestionID]
    FROM [dbo].[SecurityQuestion] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SecurityQuestionID] = @SecurityQuestionID
END