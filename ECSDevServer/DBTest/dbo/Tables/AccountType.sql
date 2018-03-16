CREATE TABLE [dbo].[AccountType] (
    [Username]       NVARCHAR (20)  NOT NULL,
    [PermissionName] NVARCHAR (128) NOT NULL,
    [RoleId]         INT            NOT NULL,
    CONSTRAINT [PK_dbo.AccountType] PRIMARY KEY CLUSTERED ([Username] ASC, [PermissionName] ASC),
    CONSTRAINT [FK_dbo.AccountType_dbo.Account_Username] FOREIGN KEY ([Username]) REFERENCES [dbo].[Account] ([UserName]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AccountType_dbo.Permission_PermissionName_RoleId] FOREIGN KEY ([PermissionName], [RoleId]) REFERENCES [dbo].[Permission] ([PermissionName], [RoleId]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_Username]
    ON [dbo].[AccountType]([Username] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PermissionName_RoleId]
    ON [dbo].[AccountType]([PermissionName] ASC, [RoleId] ASC);

