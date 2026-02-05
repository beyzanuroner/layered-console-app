using System.Collections.Generic;
using System.Linq;
using LayeredConsoleApp.Domain;

namespace LayeredConsoleApp.Infrastructure
{
    public class TaskRepository
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public TaskItem Add(string title)
        {
            var task = new TaskItem
            {
                Id = _nextId++,
                Title = title,
                IsCompleted = false
            };

            _tasks.Add(task);
            return task;
        }

        public List<TaskItem> GetAll()
        {
            return _tasks;
        }

        public TaskItem GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public bool Remove(int id)
        {
            var task = GetById(id);
            if (task == null)
                return false;

            _tasks.Remove(task);
            return true;
        }

        public bool ToggleComplete(int id)
        {
            var task = GetById(id);
            if (task == null)
                return false;

            task.IsCompleted = !task.IsCompleted;
            return true;
        }
    }
}
