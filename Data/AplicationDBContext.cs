using CrudWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options)
            : base (options)
        {
            
        }

        public DbSet <Person> Person { get; set; }
    }
}
