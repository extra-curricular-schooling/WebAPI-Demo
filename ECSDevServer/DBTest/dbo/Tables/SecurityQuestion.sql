CREATE TABLE [dbo].[SecurityQuestion] (
    [SecurityQuestionID] INT            IDENTITY (1, 1) NOT NULL,
    [SecQuestion]        NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.SecurityQuestion] PRIMARY KEY CLUSTERED ([SecurityQuestionID] ASC)
);





