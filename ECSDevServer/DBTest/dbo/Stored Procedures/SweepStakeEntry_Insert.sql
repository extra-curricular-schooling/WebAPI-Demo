CREATE PROCEDURE [dbo].[SweepStakeEntry_Insert]
    @SweepstakesID [int],
    @UserName [nvarchar](20),
    @PurchaseDateTime [datetime],
    @Cost [int],
    @OpenDateTime [datetime]
AS
BEGIN
    INSERT [dbo].[SweepStakeEntry]([SweepstakesID], [UserName], [PurchaseDateTime], [Cost], [OpenDateTime])
    VALUES (@SweepstakesID, @UserName, @PurchaseDateTime, @Cost, @OpenDateTime)
END