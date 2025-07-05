using System.Threading.Tasks;
using TestAPI.DAO;
using TestAPI.Repositories;
using TestAPI.Repositories.Interfaces;

namespace TestAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IToDoRepository? _toDoRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IToDoRepository ToDoRepository
        {
            get
            {
                return _toDoRepository ??= new ToDoRepository(_context);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}