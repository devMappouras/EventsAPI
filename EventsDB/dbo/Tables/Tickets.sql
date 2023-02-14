CREATE TABLE [dbo].[Tickets] (
    [TicketId]       INT IDENTITY (1, 1) NOT NULL,
    [OwnerId]        INT NOT NULL,
    [PurchaseId]     INT NOT NULL,
    [EventProductId] INT NOT NULL,
    [SectionId]      INT NULL,
    CONSTRAINT [FK_Tickets_Customers] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    CONSTRAINT [FK_Tickets_EventProducts] FOREIGN KEY ([EventProductId]) REFERENCES [dbo].[EventProducts] ([EventProductId]),
    CONSTRAINT [FK_Tickets_Purchases] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[Purchases] ([PurchaseId]),
    CONSTRAINT [FK_Tickets_Sections] FOREIGN KEY ([SectionId]) REFERENCES [dbo].[Sections] ([SectionId])
);



