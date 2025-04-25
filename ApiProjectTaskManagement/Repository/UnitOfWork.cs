using ApiProjectTaskManagement.Data;
using ApiProjectTaskManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  ApiProjectTaskManagement.Models;

namespace ApiProjectTaskManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Backing field for Task repository
        private ITaskRepository<TaskModel> _taskRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ITaskRepository<TaskModel> Task
        {
            get
            {
                return _taskRepository ??= new TaskRepository<TaskModel>(_context);
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
