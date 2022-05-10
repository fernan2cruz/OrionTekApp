using Microsoft.EntityFrameworkCore;
using OrionTek.Entities;

namespace OrionTek.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Entidades 
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
