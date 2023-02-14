CREATE TABLE [dbo].[Purchases] (
    [PurchaseId]       INT IDENTITY (1, 1) NOT NULL,
    [BuyerId]          INT NOT NULL,
    [PurchaseStatusId] INT NOT NULL,
    CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED ([PurchaseId] ASC),
    CONSTRAINT [FK_Purchases_Customers] FOREIGN KEY ([BuyerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    CONSTRAINT [FK_Purchases_PurchaseStatus] FOREIGN KEY ([PurchaseStatusId]) REFERENCES [dbo].[PurchaseStatus] ([PurchaseStatusId])
);





