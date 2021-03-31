CREATE TABLE [dbo].[Transactions] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [TransactionDate]   DATETIME2 (7)   NOT NULL,
    [TransactionType]   INT             NOT NULL,
    [TransactionAmount] DECIMAL (18, 2) NOT NULL,
    [AccountId]         INT             NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Accounts_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Accounts] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Transactions_AccountId]
    ON [dbo].[Transactions]([AccountId] ASC);

