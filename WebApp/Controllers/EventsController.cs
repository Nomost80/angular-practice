using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model.Entities;
using Services;
using WebApp.Core;
using WebApp.Dtos;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EventsController : ControllerBase
	{
		private readonly IEventService _eventService;
		private readonly IMapper _mapper;

		public EventsController(IEventService eventService, IMapper mapper)
		{
			_eventService = eventService;
			_mapper = mapper;
		}
		
		[HttpGet(Name = "GetAllEvents")]
		public IActionResult GetAllEvents()
		{
			var events = _eventService.GetAllEvents();
			var response = new ServerResponse<IEnumerable<Event>>();
			response.Data = events;
			return Ok(response);
		}

		[HttpGet("{id}", Name = "GetEvent")]
		public IActionResult GetEvent(int id)
		{
			var response = new ServerResponse<Event>();
			var evt = _eventService.GetEvent(id);
			
			if (evt is null)
			{
				response.Message = "Event not found";
				return NotFound(response);
			}
			
			response.Data = evt;
			return Ok(response);
		}

		[HttpPost(Name = "CreateEvent")]
		public IActionResult CreateEvent([FromBody]EventFormDto eventFormDto)
		{
			if (!ModelState.IsValid)
			{
				var response = new ServerResponse<ModelStateDictionary>();
				response.Data = ModelState;
				return BadRequest(response);
			}
			else
			{
				var evt = _mapper.Map<EventFormDto, Event>(eventFormDto);
				_eventService.CreateEvent(evt);
				
				var response = new ServerResponse<Event>();
				response.Data = evt;
				response.Message = "Event successfully created !";
				return CreatedAtAction(nameof(GetEvent), new { id = evt.Id }, response);
			}
		}

		[HttpPut("{id}", Name = "UpdateEvent")]
		public IActionResult UpdateEvent(int id, [FromBody]EventFormDto eventFormDto)
		{
			if (!ModelState.IsValid)
			{
				var response = new ServerResponse<ModelStateDictionary>();
				response.Data = ModelState;
				return BadRequest(response);
			}
			else
			{
				var response = new ServerResponse<Event>();
				var evt = _eventService.GetEvent(id);

				if (evt is null)
				{
					response.Message = "Event not found";
					return NotFound(response);
				}
				
				var evtUpdated = _mapper.Map(eventFormDto, evt);
				_eventService.UpdateEvent(evtUpdated);
				
				response.Data = evtUpdated;
				response.Message = "Event successfully updated !";
				return Ok(response);				
			}
		}

		[HttpDelete("{id}", Name = "DeleteEvent")]
		public IActionResult DeleteEvent(int id)
		{
			var response = new ServerResponse<Event>();
			var evt = _eventService.GetEvent(id);
			
			if (evt is null)
			{
				response.Message = "Cannot delete an unknown event";
				return NotFound(response);
			}
			
			_eventService.DeleteEvent(evt);
			
			response.Message = "Event successfully deleted !";
			return Ok(response);
		}
	}
}