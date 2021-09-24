using KeesingTechnologies.Assessment.CalendarService.Api.Services;
using KeesingTechnologies.Assessment.CalendarService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarController : ControllerBase
    {
        private IEventsRepository _repository;
        public CalendarController(IEventsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAllEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Event>>> GetAllEvents()
        {
            var dtos = await _repository.GetEventsAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEventById")]
        public async Task<ActionResult<Event>> GetEventById(Guid id)
        {
            var evnt = await _repository.GetEventByIdAsync(id);
            if (evnt == null) return NotFound();
            return Ok(evnt);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Create([FromBody] Event model)
        {
            model.Id = new Guid();
            if(await _repository.AddEventAsync(model))
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return new NoContentResult();
            }
        }

        [HttpPut("{id}", Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(Guid id, [FromBody] Event model)
        {
            if (ModelState.IsValid)
            {
                if(await _repository.UpdateEventAsync(id, model))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
                
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}", Name = "DeleteEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(await _repository.DeleteEventAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
