using Task = TaskManagementSystem.Data.DTOs.Task;

namespace TaskManagementSystem.Data.Services
{
    public interface ITaskService
    {
        Task GetSingle(int id);
        List<Task> GetList(int? taskStatus, int? assignedTo);
        Task CreateTask(Task task);
        Task UpdateTask(Task task);
        bool TrashTask(int taskId);

    }
}
