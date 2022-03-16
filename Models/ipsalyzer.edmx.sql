
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/11/2022 23:47:59
-- Generated from EDMX file: C:\inetpub\wwwroot\IPSAlyzer_v1\Models\ipsalyzer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\kevin\Ipsalyzer\IPSAlyzer_v1\App_Data\Ipsalyzer.mdf];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Product_FuncProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Product_FuncProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_Product_CatProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Product_CatProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Product_Func]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Func];
GO
IF OBJECT_ID(N'[dbo].[Product_Cat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Cat];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Product_Func'
CREATE TABLE [dbo].[Product_Func] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Product_Cat'
CREATE TABLE [dbo].[Product_Cat] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Product_FuncId] int  NOT NULL,
    [Product_CatId] int  NULL,
    [Name] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Pic_link] nvarchar(max)  NULL,
    [Usage] nvarchar(max)  NULL,
    [Usage_Pic] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Product_Func'
ALTER TABLE [dbo].[Product_Func]
ADD CONSTRAINT [PK_Product_Func]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product_Cat'
ALTER TABLE [dbo].[Product_Cat]
ADD CONSTRAINT [PK_Product_Cat]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Product_FuncId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Product_FuncProduct]
    FOREIGN KEY ([Product_FuncId])
    REFERENCES [dbo].[Product_Func]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Product_FuncProduct'
CREATE INDEX [IX_FK_Product_FuncProduct]
ON [dbo].[Products]
    ([Product_FuncId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------