using CoreLIS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreLIS.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<User> Users { get; set; }        
        public DbSet<Value> Values { get; set; }
    }
}