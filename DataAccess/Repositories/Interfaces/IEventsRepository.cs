﻿using DataAccess.Models;
using DataAccess.Models.Responses;

namespace DataAccess.Repositories.Interfaces;

public interface IEventsRepository
{
    Task<EventModel?> GetEventById(int id);
    Task<IEnumerable<GetEventsResponse>> GetHomeScreenEvents(int OrganiserId);
}