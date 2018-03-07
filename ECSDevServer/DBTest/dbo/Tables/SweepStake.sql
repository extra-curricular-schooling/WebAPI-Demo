CREATE TABLE [dbo].[SweepStake] (
    [SweepStakesID]  INT            IDENTITY (1, 1) NOT NULL,
    [OpenDateTime]   DATETIME       NOT NULL,
    [ClosedDateTime] DATETIME       NOT NULL,
    [Prize]          NVARCHAR (MAX) NOT NULL,
    [UsernameWinner] NVARCHAR (20)  NULL,
    CONSTRAINT [PK_dbo.SweepStake] PRIMARY KEY CLUSTERED ([SweepStakesID] ASC)
);

