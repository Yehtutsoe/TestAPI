using Microsoft.EntityFrameworkCore;
using TestAPI.Models.Entities;
using TestAPI.Repositories.Interfaces;
using TestAPI.DAO;

namespace TestAPI.Repositories
{
    public class ToDoRepository : BaseRepository<ToDoEntity>, IToDoRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoEntity>> GetPendingToDosAsync()
        {
            // Example: pending if UpdatedAt is default (not updated/completed)
            return await _context.Set<ToDoEntity>()
                .Where(todo => todo.UpdatedAt == default)
                .ToListAsync();
        }

        public async Task<IEnumerable<ToDoEntity>> GetToDosByDateAsync(DateTime date)
        {
            return await _context.Set<ToDoEntity>()
                .Where(todo => todo.CreatedAt.Date == date.Date)
                .ToListAsync();
        }

        public async Task MarkAsCompletedAsync(int id)
        {
            var todo = await _context.Set<ToDoEntity>().FindAsync(id);
            if (todo != null)
            {
                todo.UpdatedAt = DateTime.UtcNow;
                _context.Set<ToDoEntity>().Update(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
}