CREATE PROCEDURE [dbo].[SweepStake_Delete]
    @SweepStakesID [int]
AS
BEGIN
    DELETE [dbo].[SweepStake]
    WHERE ([SweepStakesID] = @SweepStakesID)
END