CREATE PROCEDURE [dbo].[SweepStakeEntry_Delete]
    @SweepstakesID [int],
    @UserName [nvarchar](20)
AS
BEGIN
    DELETE [dbo].[SweepStakeEntry]
    WHERE (([SweepstakesID] = @SweepstakesID) AND ([UserName] = @UserName))
END