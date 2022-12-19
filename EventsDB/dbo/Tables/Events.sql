CREATE TABLE [dbo].[Events] (
    [EventId]          INT                IDENTITY (1, 1) NOT NULL,
    [EventTitle]       NVARCHAR (100)     NOT NULL,
    [EventDescription] NVARCHAR (MAX)     NULL,
    [EventDateTime]    DATETIMEOFFSET (7) NOT NULL,
    [BannerImage]      NVARCHAR (50)      NULL,
    [CategoryId]       INT                NOT NULL,
    [VenueId]          INT                NOT NULL,
    [CollectionId]     INT                NULL,
    [OrganiserId]      INT                NOT NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([EventId] ASC),
    CONSTRAINT [FK_Events_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]),
    CONSTRAINT [FK_Events_Collections] FOREIGN KEY ([CollectionId]) REFERENCES [dbo].[Collections] ([CollectionId]),
    CONSTRAINT [FK_Events_Organisers] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId]),
    CONSTRAINT [FK_Events_Organisers1] FOREIGN KEY ([OrganiserId]) REFERENCES [dbo].[Organisers] ([OrganiserId]),
    CONSTRAINT [FK_Events_Venues] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venues] ([VenueId])
);


GO