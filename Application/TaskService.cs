using System.Collections.Generic;
using LayeredConsoleApp.Domain;
using LayeredConsoleApp.Infrastructure;

namespace LayeredConsoleApp.Application
{
    public class TaskService
    {
        private readonly TaskRepository _repository;

        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public bool AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return false;

            _repository.Add(title);
            return true;
        }

        public List<TaskItem> GetTasks()
        {
            return _repository.GetAll();
        }

        public bool RemoveTask(int id)
        {
            return _repository.Remove(id);
        }

        public bool ToggleTask(int id)
        {
            return _repository.ToggleComplete(id);
        }
    }
}
