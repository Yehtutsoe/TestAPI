using TestAPI.Models.Entities;

namespace TestAPI.Services.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoEntity>> GetAllAsync();
        Task<ToDoEntity?> GetByIdAsync(int id);
        Task AddAsync(ToDoEntity entity);
        Task UpdateAsync(ToDoEntity entity);
        Task DeleteAsync(int id);

        Task<IEnumerable<ToDoEntity>> GetPendingToDosAsync();
        Task<IEnumerable<ToDoEntity>> GetToDosByDateAsync(DateTime date);
        Task MarkAsCompletedAsync(int id);
    }
}