using backendP.DTOs;
using backendP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private StoreContext _context;

        public ItemController(StoreContext context) { 
             _context= context;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> Get() =>await _context.Item.Select(i => new ItemDto
        {
            ItemID=i.ItemID,
            Name=i.Name,
            Description=i.Description,
            DepartmentID=i.DepartmentID
        }).ToArrayAsync();

        [HttpGet("{ItemID}")]
        public async Task<ActionResult<ItemDto>> GetById(int ItemID)
        {
            var item=await _context.Item.FindAsync(ItemID);

            if (item==null)
            {
                return NotFound();
            }
            else
            {
            var itemDto = new ItemDto
            {
                ItemID = item.ItemID,
                Name = item.Name,
                Description = item.Description,
                DepartmentID = item.DepartmentID
            };
                return Ok(itemDto);
            }
        }
    }
}
