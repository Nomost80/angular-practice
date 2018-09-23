using Model.Entities;

namespace Services
{
	public interface IUserService
	{
		void Register(User user);
		string Authenticate(User user);
	}
}