CREATE PROCEDURE [dbo].[SweepStake_Update]
    @SweepStakesID [int],
    @OpenDateTime [datetime],
    @ClosedDateTime [datetime],
    @Prize [nvarchar](max),
    @UsernameWinner [nvarchar](20)
AS
BEGIN
    UPDATE [dbo].[SweepStake]
    SET [OpenDateTime] = @OpenDateTime, [ClosedDateTime] = @ClosedDateTime, [Prize] = @Prize, [UsernameWinner] = @UsernameWinner
    WHERE ([SweepStakesID] = @SweepStakesID)
END