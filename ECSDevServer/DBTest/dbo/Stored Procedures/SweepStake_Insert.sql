CREATE PROCEDURE [dbo].[SweepStake_Insert]
    @OpenDateTime [datetime],
    @ClosedDateTime [datetime],
    @Prize [nvarchar](max),
    @UsernameWinner [nvarchar](20)
AS
BEGIN
    INSERT [dbo].[SweepStake]([OpenDateTime], [ClosedDateTime], [Prize], [UsernameWinner])
    VALUES (@OpenDateTime, @ClosedDateTime, @Prize, @UsernameWinner)
    
    DECLARE @SweepStakesID int
    SELECT @SweepStakesID = [SweepStakesID]
    FROM [dbo].[SweepStake]
    WHERE @@ROWCOUNT > 0 AND [SweepStakesID] = scope_identity()
    
    SELECT t0.[SweepStakesID]
    FROM [dbo].[SweepStake] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[SweepStakesID] = @SweepStakesID
END