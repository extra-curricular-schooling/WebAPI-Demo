CREATE PROCEDURE [dbo].[User_Insert]
    @Email [nvarchar](128),
    @FirstName [nvarchar](50),
    @LastName [nvarchar](50)
AS
BEGIN
    INSERT [dbo].[User]([Email], [FirstName], [LastName])
    VALUES (@Email, @FirstName, @LastName)
END