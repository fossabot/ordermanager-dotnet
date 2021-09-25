using Microsoft.EntityFrameworkCore;
using ordermanger_dotnet.Entities;
using ordermanger_dotnet.Models;

namespace ordermanger_dotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<User> Users {get;set;}
    }
}
