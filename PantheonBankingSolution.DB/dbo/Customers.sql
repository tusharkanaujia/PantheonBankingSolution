﻿CREATE TABLE [dbo].[Customers] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerFullName] NVARCHAR (MAX) NULL,
    [UserName]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

