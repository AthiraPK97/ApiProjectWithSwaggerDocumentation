using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Data;
using ApiProjectTaskManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectTaskManagement.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks() =>
            await _context.Tasks.ToListAsync();

        public async Task<TaskModel> GetTaskById(int id) =>
            await _context.Tasks.FindAsync(id);

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateTask(TaskModel task)
        {
            _context.Tasks.Update(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
