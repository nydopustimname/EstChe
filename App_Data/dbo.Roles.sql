CREATE TABLE [dbo].[Roles] (
    [RoleId]   INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC),
    UNIQUE NONCLUSTERED ([RoleName] ASC)
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
ON [dbo].[Roles]([RoleName] ASC);
