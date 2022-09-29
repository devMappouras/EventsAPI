CREATE TABLE [dbo].[EventProducts] (
    [EventProductId] INT NOT NULL,
    [EventId]        INT NOT NULL,
    [ProductId]      INT NOT NULL,
    CONSTRAINT [PK_EventProducts] PRIMARY KEY CLUSTERED ([EventProductId] ASC),
    CONSTRAINT [FK_EventProducts_Events] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Events] ([EventId]),
    CONSTRAINT [FK_EventProducts_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

