using PauloApi.Models;

namespace PauloApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Login(string username, string password);
    }
}
