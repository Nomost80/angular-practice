using Data.Abstract;
using Model.Entities;

namespace Data.Repositories
{
	public class EventRepository : EntityBaseRepository<Event>, IEventRepository
	{
		public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}
	}
}