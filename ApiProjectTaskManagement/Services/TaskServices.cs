using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Models;
using ApiProjectTaskManagement.Repository;

namespace ApiProjectTaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks() => await _taskRepository.GetAllTasks();

        public async Task<TaskModel> GetTaskById(int id) => await _taskRepository.GetTaskById(id);

        public async Task<TaskModel> AddTask(TaskModel task) => await _taskRepository.AddTask(task);

        public async Task<bool> UpdateTask(TaskModel task) => await _taskRepository.UpdateTask(task);

        public async Task<bool> DeleteTask(int id) => await _taskRepository.DeleteTask(id);
    }
}
