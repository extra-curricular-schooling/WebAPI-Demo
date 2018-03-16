CREATE TABLE [dbo].[Permission] (
    [PermissionName] NVARCHAR (128) NOT NULL,
    [RoleId]         INT            NOT NULL,
    CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED ([PermissionName] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.Permission_dbo.Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[Permission]([RoleId] ASC);

