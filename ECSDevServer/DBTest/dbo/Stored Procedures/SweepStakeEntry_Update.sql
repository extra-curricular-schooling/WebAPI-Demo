CREATE PROCEDURE [dbo].[SweepStakeEntry_Update]
    @SweepstakesID [int],
    @UserName [nvarchar](20),
    @PurchaseDateTime [datetime],
    @Cost [int],
    @OpenDateTime [datetime]
AS
BEGIN
    UPDATE [dbo].[SweepStakeEntry]
    SET [PurchaseDateTime] = @PurchaseDateTime, [Cost] = @Cost, [OpenDateTime] = @OpenDateTime
    WHERE (([SweepstakesID] = @SweepstakesID) AND ([UserName] = @UserName))
END