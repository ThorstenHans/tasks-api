using System;
using System.Collections.Generic;
using Tasks.API.Models;

namespace Tasks.API.Repositories
{
    public interface ITasksRepository
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(Guid id);
        Task CreateTask(Task task);
        Task UpdateTask(Guid id, Task task);
        bool DeleteTask(Guid id);
    }
}
