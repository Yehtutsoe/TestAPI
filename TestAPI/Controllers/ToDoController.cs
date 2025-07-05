using Microsoft.AspNetCore.Mvc;
using TestAPI.Models.Entities;
using TestAPI.Services.Interfaces;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _toDoService.GetAllAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _toDoService.GetByIdAsync(id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ToDoEntity entity)
        {
            await _toDoService.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ToDoEntity entity)
        {
            if (id != entity.Id)
                return BadRequest();

            await _toDoService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _toDoService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPending()
        {
            var todos = await _toDoService.GetPendingToDosAsync();
            return Ok(todos);
        }

        [HttpGet("bydate/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date)
        {
            var todos = await _toDoService.GetToDosByDateAsync(date);
            return Ok(todos);
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            await _toDoService.MarkAsCompletedAsync(id);
            return NoContent();
        }
    }
}