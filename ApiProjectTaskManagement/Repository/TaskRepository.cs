using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Data;
using ApiProjectTaskManagement.Models;
using Microsoft.EntityFrameworkCore;
using ApiProjectTaskManagement.Data;
using ApiProjectTaskManagement.Interfaces;

namespace ApiProjectTaskManagement.Repository
{
    public class TaskRepository<T> : ITaskRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}