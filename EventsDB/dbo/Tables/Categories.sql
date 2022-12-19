CREATE TABLE [dbo].[Categories] (
    [CategoryId]   INT           NOT NULL,
    [CategoryName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

