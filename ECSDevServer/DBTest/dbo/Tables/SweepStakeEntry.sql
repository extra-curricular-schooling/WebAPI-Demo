CREATE TABLE [dbo].[SweepStakeEntry] (
    [SweepstakesID]    INT           NOT NULL,
    [UserName]         NVARCHAR (20) NOT NULL,
    [PurchaseDateTime] DATETIME      NOT NULL,
    [Cost]             INT           NOT NULL,
    [OpenDateTime]     DATETIME      NOT NULL,
    CONSTRAINT [PK_dbo.SweepStakeEntry] PRIMARY KEY CLUSTERED ([SweepstakesID] ASC, [UserName] ASC),
    CONSTRAINT [FK_dbo.SweepStakeEntry_dbo.Account_UserName] FOREIGN KEY ([UserName]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.SweepStakeEntry_dbo.SweepStake_SweepstakesID] FOREIGN KEY ([SweepstakesID]) REFERENCES [dbo].[SweepStake] ([SweepStakesID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_SweepstakesID]
    ON [dbo].[SweepStakeEntry]([SweepstakesID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserName]
    ON [dbo].[SweepStakeEntry]([UserName] ASC);

