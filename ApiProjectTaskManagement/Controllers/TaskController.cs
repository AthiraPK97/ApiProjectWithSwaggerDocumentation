using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Models;
using ApiProjectTaskManagement.Services;
using System;

namespace ApiProjectTaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasks();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching tasks.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            try
            {
                var task = await _taskService.GetTaskById(id);
                if (task == null) return NotFound(new { message = "Task not found." });
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching the task.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask(TaskModel task)
        {
            try
            {
                var createdTask = await _taskService.AddTask(task);
                return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the task.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskModel task)
        {
            if (id != task.Id) return BadRequest(new { message = "Task ID mismatch." });

            try
            {
                var result = await _taskService.UpdateTask(task);
                return result ? NoContent() : NotFound(new { message = "Task not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the task.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var result = await _taskService.DeleteTask(id);
                return result ? NoContent() : NotFound(new { message = "Task not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the task.", error = ex.Message });
            }
        }
    }
}
 