using System.Collections.Generic;
using Model.Entities;

namespace Services
{
	public interface IEventService
	{
		IEnumerable<Event> GetAllEvents();
		Event GetEvent(int id);
		void CreateEvent(Event evt);
		void UpdateEvent(Event evt);
		void DeleteEvent(Event evt);
	}
}