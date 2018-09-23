using Model.Entities;

namespace Data.Abstract
{
	public interface IEventRepository : IEntityBaseRepository<Event> {}
	
	public interface IUserRepository : IEntityBaseRepository<User> {}
}