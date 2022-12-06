CREATE TABLE [dbo].[Countries] (
    [CountryId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);





