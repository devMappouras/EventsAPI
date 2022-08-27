﻿using DataAccess.Models.Responses;

namespace EventsAPI.Services.Interfaces
{
    public interface IEventsService
    {
        Task InsertEvent(EventModel Event);

        Task UpdateEvent(EventModel Event);

        Task DeleteEvent(int id);

        Task<EventModel> GetEventById(int id);

        Task<IEnumerable<GetEventsResponse>> GetEvents();
    }
}