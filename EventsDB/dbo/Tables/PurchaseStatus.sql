CREATE TABLE [dbo].[PurchaseStatus] (
    [PurchaseStatusId] INT           NOT NULL,
    [Name]             NVARCHAR (50) NULL,
    CONSTRAINT [PK_PurchaseStatus] PRIMARY KEY CLUSTERED ([PurchaseStatusId] ASC)
);

