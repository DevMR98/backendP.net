using backendP.Models;
using Microsoft.EntityFrameworkCore;

namespace backendP.Repository
{
    public class DepartmentRepository:IDepartmentRepository<Department>
    {
        private StoreContext _storeContext;
        public DepartmentRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IEnumerable<Department>> Get() => await _storeContext.Department.ToListAsync();
    }
}
