CREATE TABLE [dbo].[Customers] (
    [CustomerId]   INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (50)  NOT NULL,
    [CountryId]    INT            NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [PasswordSalt] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    CONSTRAINT [FK_Customers_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([CountryId])
);



