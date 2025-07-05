using Microsoft.EntityFrameworkCore;
using TestAPI.Models.Entities;

namespace TestAPI.DAO
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){ }
        public DbSet<ToDoEntity> toDoEntities { get; set; }
    
    }
}
