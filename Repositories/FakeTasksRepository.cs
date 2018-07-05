using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.API.Models;

namespace Tasks.API.Repositories
{
    public class FakeTasksRepository : ITasksRepository
    {
        private readonly List<Task> _tasks = new List<Task>
        {
            new Task {Id = Guid.NewGuid(), Title = "Buy Milk", CreatedAt = DateTime.UtcNow}
        };

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks;
        }

        public Task GetTaskById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public Task CreateTask(Task task)
        {
            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.UtcNow;
            _tasks.Add(task);
            return task;
        }

        public Task UpdateTask(Guid id, Task task)
        {
            var originalTask = GetTaskById(id);
            if (originalTask == null) return originalTask;
            
            originalTask.Title = task.Title;
            originalTask.Description = task.Description;
            originalTask.IsCompleted = task.IsCompleted;
            originalTask.IsDeleted = task.IsDeleted;

            return originalTask;
        }

        public bool DeleteTask(Guid id)
        {
            var originalTask = GetTaskById(id);
            if (originalTask == null) return false;
            _tasks.Remove(originalTask);
            return true;
        }
    }
}