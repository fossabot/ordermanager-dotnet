using Microsoft.EntityFrameworkCore;
using ordermanager_dotnet.Entities;
using ordermanager_dotnet.Models;

namespace ordermanager_dotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<User> Users {get;set;}

        public DbSet<Manufacturer> Manufacturers {get;set;}

        public DbSet<Model> Models {get;set;}

        public DbSet<Machine> Machines {get;set;}
    }
}
