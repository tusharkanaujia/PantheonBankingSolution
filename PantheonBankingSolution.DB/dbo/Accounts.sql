CREATE TABLE [dbo].[Accounts] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [AccountNumber]  INT             NOT NULL,
    [CurrentBalance] DECIMAL (18, 2) NOT NULL,
    [CustomerId]     INT             NULL,
    CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Accounts_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Accounts_CustomerId]
    ON [dbo].[Accounts]([CustomerId] ASC);

