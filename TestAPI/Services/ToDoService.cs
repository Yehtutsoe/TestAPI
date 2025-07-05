using TestAPI.Models.Entities;
using TestAPI.Services.Interfaces;
using TestAPI.UnitOfWork;

namespace TestAPI.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ToDoEntity>> GetAllAsync()
        {
            return await _unitOfWork.ToDoRepository.GetAllSync();
        }

        public async Task<ToDoEntity?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ToDoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ToDoEntity entity)
        {
            await _unitOfWork.ToDoRepository.AddSync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ToDoEntity entity)
        {
            _unitOfWork.ToDoRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ToDoRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _unitOfWork.ToDoRepository.Delete(entity);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<IEnumerable<ToDoEntity>> GetPendingToDosAsync()
        {
            return await _unitOfWork.ToDoRepository.GetPendingToDosAsync();
        }

        public async Task<IEnumerable<ToDoEntity>> GetToDosByDateAsync(DateTime date)
        {
            return await _unitOfWork.ToDoRepository.GetToDosByDateAsync(date);
        }

        public async Task MarkAsCompletedAsync(int id)
        {
            await _unitOfWork.ToDoRepository.MarkAsCompletedAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}