using TDDProject.Models;

namespace TDDProject.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }
    public class UsersService : IUsersService
    {
        public UsersService()
        {
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
