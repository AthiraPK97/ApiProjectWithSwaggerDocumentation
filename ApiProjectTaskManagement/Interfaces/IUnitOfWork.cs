using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Interfaces;
using ApiProjectTaskManagement.Models;
using ApiProjectTaskManagement.Repository;

namespace ApiProjectTaskManagement.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository<TaskModel> Task { get; }
        Task<int> CompleteAsync();
    }
}
