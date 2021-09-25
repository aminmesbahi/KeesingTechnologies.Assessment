using KeesingTechnologies.Assessment.CalendarService.Api.Services;
using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private readonly IEventsRepository _repository;
        private readonly IActionContextAccessor _contextAccessor;
        public CalendarController(IEventsRepository repository, IActionContextAccessor contextAccessor)
        {
            _repository = repository;
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Adding a new event - POST request should be created to add a new event. The API endpoint would be /calendar.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Create([FromBody] Event model)
        {
            model.Id = new Guid();
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                if (_contextAccessor.ActionContext.HttpContext.Connection.RemoteIpAddress != null)
                    model.CreatedByIp =
                        _contextAccessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
                await _repository.AddEventAsync(model);
                return StatusCode(StatusCodes.Status201Created);

            }
            else
            {
                return new BadRequestResult();
            }
        }


        /// <summary>
        /// Deleting any event by id -  DELETE request to endpoint /calendar/{id} should delete the event. If the item does not exist return not found.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _repository.DeleteEventAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }


        /// <summary>
        /// Editing the event - PUT request to endpoint /calendar/{id}. If the item does not exist return not found.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}", Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] Event model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _repository.UpdateEventAsync(id, model))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }



        /// <summary>
        /// Getting all events - GET request to endpoint /calendar should return all the events in the system. The HTTP response code should be 200. If no event exists, return the empty array.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            var dtos = await _repository.GetEventsAsync();
            return Ok(dtos);
        }



        /// <summary>
        /// Getting all events of the organizer - GET request to endpoint /calendar/query?eventOrganizer={eventOrganizer} should return the entire list of events organized by this organizer.
        /// </summary>
        /// <param name="eventOrganizer"></param>
        /// <returns></returns>
        [HttpGet(template: "{eventOrganizer}", Name = "GetEventsByEventOrganizer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Event>>> GetEventsByEventOrganizer(string eventOrganizer)
        {
            var dtos = await _repository.GetEventsByOrganizerAsync(eventOrganizer);
            return Ok(dtos);
        }

        /// <summary>
        /// Getting event by id - GET request to endpoint /calendar/{id} should return the details of the event with this unique id. The HTTP response code should be 200.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            var evnt = await _repository.GetEventByIdAsync(id);
            if (evnt == null) return NotFound();
            return Ok(evnt);
        }


        /// <summary>
        /// Sort the event as per the time - GET request to endpoint /calendar/sort should return the events sorted in descending order of time. 
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "sort",Name = "GetEventsSortedByTime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Event>>> GetEventsSortedByTime()
        {
            var dtos = await _repository.GetEventsSortedAsync(EventSorts.ByTimeDescending);
            return Ok(dtos);
        }



    }
}
