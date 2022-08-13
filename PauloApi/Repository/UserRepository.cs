using PauloApi.Data;
using PauloApi.Models;
using PauloApi.Repository.Interfaces;

namespace PauloApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PauloContext _context;

        public UserRepository(PauloContext context)
        {
            _context = context;
        }

        public User Login(string username, string password)
        {
            return _context.users.FirstOrDefault(user => user.Username == username && user.Password == password);
        }
    }
}
