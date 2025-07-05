using System.Threading.Tasks;
using TestAPI.Repositories.Interfaces;

namespace TestAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDoRepository { get; }
        Task<int> SaveAsync();
    }
}