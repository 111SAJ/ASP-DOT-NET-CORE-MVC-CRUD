using Crud.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<EmployeeRegister> EmployeeRegister { get; set; }

    }
}
