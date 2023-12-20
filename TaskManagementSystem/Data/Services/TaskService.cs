using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using TaskManagementSystem.Data.DTOs;
using Task = TaskManagementSystem.Data.DTOs.Task;

namespace TaskManagementSystem.Data.Services
{
    public class TaskService : ITaskService
    {
        private TMSContext _dbContext;
        private IHttpContextAccessor _httpContextAccessor;
        public TaskService(TMSContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task CreateTask(Task task)
        {
            try
            {
                _dbContext.Add(task);
                _dbContext.SaveChanges();
                return task;
            }
            catch (Exception e)
            {
                _dbContext.Add(Log.ErrorLog(e.StackTrace, "Create Task fails.", _httpContextAccessor));
                _dbContext.SaveChanges();
            }
            return null;
        }

        public List<Task> GetList(int? taskStatus, int? assignedTo)
        {
            try
            {
                return _dbContext.Tasks.Where(task => (taskStatus == null || (taskStatus != null && task.TaskStatus == taskStatus)) && (assignedTo == null || (assignedTo != null && task.AssignedTo == assignedTo))).ToList(); ;
            }
            catch (Exception e)
            {
                _dbContext.Add(Log.ErrorLog(e.StackTrace, "Task Get List fails.", _httpContextAccessor));
                _dbContext.SaveChanges();
            }
            return new List<Task>();
        }

        public Task GetSingle(int id)
        {
            try
            {
                return _dbContext.Tasks.Single(task => task.TaskId == id); ;
            }
            catch (Exception e)
            {
                _dbContext.Add(Log.ErrorLog(e.StackTrace, "Task Get Single fails.", _httpContextAccessor));
                _dbContext.SaveChanges();
            }
            return null;
        }

        public bool TrashTask(int taskId)
        {
            try
            {
                var taskDb = _dbContext.Tasks.SingleOrDefault(t => t.TaskId == taskId);
                if (taskDb != null)
                {
                    taskDb.Trashed = true;
                    _dbContext.Update(taskDb);
                    _dbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                _dbContext.Add(Log.ErrorLog(e.StackTrace, "Delete Task fails.", _httpContextAccessor));
                _dbContext.SaveChanges();
            }
            return false;
        }

        public Task UpdateTask(Task task)
        {
            try
            {
                _dbContext.Update(task);
                _dbContext.SaveChanges();
                return task;
            }
            catch (Exception e)
            {
                _dbContext.Add(Log.ErrorLog(e.StackTrace, "Update Task fails.", _httpContextAccessor));
                _dbContext.SaveChanges();
            }
            return null;
        }
    }
}
