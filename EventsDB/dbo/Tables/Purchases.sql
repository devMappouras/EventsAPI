CREATE TABLE [dbo].[Purchases] (
    [PurchaseId]       INT NOT NULL,
    [EventProductId]   INT NOT NULL,
    [CustomerId]       INT NOT NULL,
    [PurchaseStatusId] INT NOT NULL,
    CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED ([PurchaseId] ASC),
    CONSTRAINT [FK_Purchases_EventProducts] FOREIGN KEY ([EventProductId]) REFERENCES [dbo].[EventProducts] ([EventProductId]),
    CONSTRAINT [FK_Purchases_PurchaseStatus] FOREIGN KEY ([PurchaseStatusId]) REFERENCES [dbo].[PurchaseStatus] ([PurchaseStatusId])
);

