using Microsoft.EntityFrameworkCore;

namespace backendP.Models
{
    public class StoreContext:DbContext
    {
        //el constructor recibe por parametros los datos de la conecion mediante DbContextOptions
        public StoreContext(DbContextOptions<StoreContext> options):base(options) { 
        
        }

       public DbSet<Department> Department { get; set; }
       public DbSet<Item> Item { get; set; }

    }
}
