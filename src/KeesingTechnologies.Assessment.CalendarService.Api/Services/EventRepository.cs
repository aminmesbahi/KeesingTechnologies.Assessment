using KeesingTechnologies.Assessment.CalendarService.Api.Data;
using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Services
{
    public class EventsRepository : IEventsRepository, IDisposable
    {
        private EventContext _context;
        private CancellationTokenSource _cancellationTokenSource;

        public EventsRepository(EventContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> AddEventAsync(Event newEvent)
        {
            if (newEvent == null)
            {
                throw new ArgumentNullException(nameof(newEvent));
            }
            _context.Events.Add(newEvent);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteEventAsync(Guid id)
        {
            if (EventExists(id)) {
                _context.Events.Remove(_context.Events.FirstOrDefault(e => e.Id == id) ?? new Event());
                if (await SaveChangesAsync())
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateEventAsync(Guid id, Event updatedEvent)
        {
            if (EventExists(id))
            {
                _context.Update(updatedEvent);
                return await SaveChangesAsync();

            }
            return false;
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            var events = await _context.Events.ToListAsync();
            return events;
        }

        public IEnumerable<Event> GetEventsByOrganizer(string eventOrganizer)
        {
            return _context.Events.Where(e=>e.EventOrganizer==eventOrganizer).ToList();
        }

        public async Task<Event> GetEventByIdAsync (Guid id)
        {
            return await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public bool EventExists(Guid id)
        {
            return (_context.Events.Where(e => e.Id == id).Count() == 0 ? false:true);
        }                       

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }

                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Dispose();
                    _cancellationTokenSource = null;
                }
            }
        }
    }
}
