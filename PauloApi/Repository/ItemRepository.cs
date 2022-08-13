using Microsoft.EntityFrameworkCore;
using PauloApi.Data;
using PauloApi.Models;
using PauloApi.Repository.Interfaces;

namespace PauloApi.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly PauloContext _context;

        public ItemRepository(PauloContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> FindItems()
        {
            return await _context.items.ToListAsync();
        }
    }
}
