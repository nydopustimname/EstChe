ALTER TABLE AspNetRoles
ADD Discriminator varchar(25)
GO
UPDATE AspNetRoles SET Discriminator = 'ApplicationRole'