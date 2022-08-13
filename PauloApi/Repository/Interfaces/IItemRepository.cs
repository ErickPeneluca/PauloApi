using PauloApi.Models;

namespace PauloApi.Repository.Interfaces
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> FindItems();
    }
}
