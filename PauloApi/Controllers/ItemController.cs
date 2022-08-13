using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PauloApi.Repository.Interfaces;
using System.Data;

namespace PauloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _repository;

        public ItemController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _repository.FindItems();
            return items.Any()
                ? Ok(items)
                : NoContent();
        }
    }
}
