using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Models;

namespace ApiProjectTaskManagement.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<bool> UpdateTask(TaskModel task);
        Task<bool> DeleteTask(int id);
    }
}
