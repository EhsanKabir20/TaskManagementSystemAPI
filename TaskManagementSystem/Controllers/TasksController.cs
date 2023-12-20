
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskManagementSystem.Data.DTOs;
using TaskManagementSystem.Data.Services;
using TaskManagementSystem.Models.Users;
using Task = TaskManagementSystem.Data.DTOs.Task;

namespace TaskManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskService _taskService;

        public TasksController(ILogger<TasksController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetTask")]
        public Task Get(int id)
        {
            return _taskService.GetSingle(id);
        }

        [Authorize]
        [HttpGet(Name = "GetTasks")]
        public List<Task> Get(int? taskStatus, int? assignedTo)
        {
            return _taskService.GetList(taskStatus, assignedTo);
        }

        [Authorize]
        [HttpPost(Name = "CreateTask")]
        public Task Post(Task task)
        {
            return _taskService.CreateTask(task);
        }

        [Authorize]
        [HttpPut(Name = "UpdateTask")]
        public Task Put(Task task)
        {
            return _taskService.UpdateTask(task);
        }

        [Authorize]
        [HttpDelete("{id}", Name = "DeleteTask")]
        public bool Delete(int id)
        {
            return _taskService.TrashTask(id);
        }
    }
}