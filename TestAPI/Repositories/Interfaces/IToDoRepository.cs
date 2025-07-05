using TestAPI.Models.Entities;

namespace TestAPI.Repositories.Interfaces
{
    public interface IToDoRepository : IBaseRepository<ToDoEntity>
    {
        Task<IEnumerable<ToDoEntity>> GetPendingToDosAsync();
        Task<IEnumerable<ToDoEntity>> GetToDosByDateAsync(DateTime date);
        Task MarkAsCompletedAsync(int id);
    }
}