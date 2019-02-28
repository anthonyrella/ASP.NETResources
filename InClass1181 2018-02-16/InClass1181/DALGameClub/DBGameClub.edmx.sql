
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/30/2018 08:26:33
-- Generated from EDMX file: D:\Demos\PROG35142\InClass1181\DALGameClub\DBGameClub.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GameClub1181];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MemberGame'
CREATE TABLE [dbo].[MemberGame] (
    [Members_Id] int  NOT NULL,
    [Games_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Members_Id], [Games_Id] in table 'MemberGame'
ALTER TABLE [dbo].[MemberGame]
ADD CONSTRAINT [PK_MemberGame]
    PRIMARY KEY CLUSTERED ([Members_Id], [Games_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Members_Id] in table 'MemberGame'
ALTER TABLE [dbo].[MemberGame]
ADD CONSTRAINT [FK_MemberGame_Member]
    FOREIGN KEY ([Members_Id])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Games_Id] in table 'MemberGame'
ALTER TABLE [dbo].[MemberGame]
ADD CONSTRAINT [FK_MemberGame_Game]
    FOREIGN KEY ([Games_Id])
    REFERENCES [dbo].[Games]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberGame_Game'
CREATE INDEX [IX_FK_MemberGame_Game]
ON [dbo].[MemberGame]
    ([Games_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------