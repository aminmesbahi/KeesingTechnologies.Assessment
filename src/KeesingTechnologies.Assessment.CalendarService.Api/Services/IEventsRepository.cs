using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Services
{
    public interface IEventsRepository
    {
        Task<bool> AddEventAsync(Event newEvent);
        Task<bool> DeleteEventAsync(Guid id);
        Task<bool> UpdateEventAsync(Guid id, Event newEvent);

        Task<IEnumerable<Event>> GetEventsAsync();
        Task<IEnumerable<Event>> GetEventsByOrganizerAsync(string eventOrganizer);
        Task<Event> GetEventByIdAsync(Guid id);
        Task<ICollection<Event>> GetEventsSortedAsync(EventSorts sortOrder);
        bool EventExists(Guid id);
        Task<bool> SaveChangesAsync();
    }
}
