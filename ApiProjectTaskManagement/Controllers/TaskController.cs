using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProjectTaskManagement.Models;
using ApiProjectTaskManagement.Services;
using System;
using ApiProjectTaskManagement.Interfaces;

namespace ApiProjectTaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _task = await _unitOfWork.Task.GetAllAsync();
            return Ok(_task);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskModel _task)
        {
            await _unitOfWork.Task.AddAsync(_task);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(Get), new { id = _task.Id }, _task);
        }
    }
}