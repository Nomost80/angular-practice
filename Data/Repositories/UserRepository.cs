using Data.Abstract;
using Model.Entities;

namespace Data.Repositories
{
	public class UserRepository : EntityBaseRepository<User>, IUserRepository
	{
		public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}
	}
}