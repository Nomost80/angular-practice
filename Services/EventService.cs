using System.Collections.Generic;
using Data.Abstract;
using Model.Entities;

namespace Services
{
	public class EventService : IEventService
	{
		private readonly IEventRepository _eventRepository;

		public EventService(IEventRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}

		public IEnumerable<Event> GetAllEvents()
		{
			return _eventRepository.GetAll();
		}

		public Event GetEvent(int id)
		{
			return _eventRepository.GetSingle(id);
		}

		public void CreateEvent(Event evt)
		{
			_eventRepository.Add(evt);
			_eventRepository.Commit();
		}

		public void UpdateEvent(Event evt)
		{
			_eventRepository.Update(evt);
			_eventRepository.Commit();
		}

		public void DeleteEvent(Event evt)
		{
			_eventRepository.Delete(evt);
			_eventRepository.Commit();
		}
	}
}