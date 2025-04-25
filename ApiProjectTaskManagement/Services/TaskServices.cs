using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Models;
using ApiProjectTaskManagement.Repository;

namespace ApiProjectTaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository<TaskModel> _taskRepository;

        public TaskService(ITaskRepository<TaskModel> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<TaskModel> AddAsync(TaskModel task)
        {
            await _taskRepository.AddAsync(task);
            return task;
        }

        public async Task<bool> Update(TaskModel task)
        {
            _taskRepository.Update(task);
            return await Task.FromResult(true); // Just to maintain async signature
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null) return false;

            _taskRepository.Delete(task);
            return true;
        }

        public Task<TaskModel> AddTask(TaskModel task)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateTask(TaskModel task)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteTask(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
