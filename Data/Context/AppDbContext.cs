using Microsoft.EntityFrameworkCore;
using School.Data.Entity;

namespace School.Data.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}