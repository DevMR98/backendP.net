using backendP.DTOs;
using backendP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace backendP.Repository
{
    public class ItemRepository : IRepository<Item>
    {
        private StoreContext _storeContext;


        public ItemRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IEnumerable<Item>> Get() =>await _storeContext.Item.ToListAsync();

        public async Task<Item> GetById(int id) => await _storeContext.Item.FindAsync(id);
        public async Task Add(Item entity)=>await _storeContext.Item.AddAsync(entity);
        public void Update(Item entity)
        {
            //adjunta la entidad a tu contexto cuando ya existe
            _storeContext.Item.Attach(entity);
            _storeContext.Item.Entry(entity).State=EntityState.Modified;
        }

        public void Delete(Item entity)=>_storeContext.Remove(entity);
        public async Task Save() =>await _storeContext.SaveChangesAsync();

        
    }
}
