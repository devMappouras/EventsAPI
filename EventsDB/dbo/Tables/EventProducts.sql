CREATE TABLE [dbo].[EventProducts] (
    [EventProductId] INT IDENTITY (1, 1) NOT NULL,
    [EventId]        INT NOT NULL,
    [ProductId]      INT NOT NULL,
    CONSTRAINT [PK_EventProducts] PRIMARY KEY CLUSTERED ([EventProductId] ASC),
    CONSTRAINT [FK_EventProducts_Events] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([EventId]),
    CONSTRAINT [FK_EventProducts_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EventProducts_Unique_Event_Product]
    ON [dbo].[EventProducts]([EventId] ASC, [ProductId] ASC);

