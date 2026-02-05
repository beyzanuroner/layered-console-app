using System;
using LayeredConsoleApp.Application;

namespace LayeredConsoleApp.Presentation
{
    public class ConsoleUI
    {
        private readonly TaskService _taskService;

        public ConsoleUI(TaskService taskService)
        {
            _taskService = taskService;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                ShowMenu();

                Console.Write("Seçimin: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ListTasks();
                        break;
                    case "3":
                        ToggleTask();
                        break;
                    case "4":
                        RemoveTask();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        Pause();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("=== TASK MANAGEMENT ===");
            Console.WriteLine("1 - Görev Ekle");
            Console.WriteLine("2 - Görevleri Listele");
            Console.WriteLine("3 - Görev Tamamla / Geri Al");
            Console.WriteLine("4 - Görev Sil");
            Console.WriteLine("5 - Çıkış");
            Console.WriteLine();
        }

        private void AddTask()
        {
            Console.Clear();
            Console.Write("Görev başlığı: ");
            string title = Console.ReadLine();

            bool success = _taskService.AddTask(title);

            Console.WriteLine(success
                ? "Görev eklendi."
                : "Görev eklenemedi.");

            Pause();
        }

        private void ListTasks()
        {
            Console.Clear();
            var tasks = _taskService.GetTasks();

            if (tasks.Count == 0)
            {
                Console.WriteLine("Henüz görev yok.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    string status = task.IsCompleted ? "[X]" : "[ ]";
                    Console.WriteLine($"{task.Id}. {status} {task.Title}");
                }
            }

            Pause();
        }

        private void ToggleTask()
        {
            Console.Clear();
            Console.Write("Görev ID: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool success = _taskService.ToggleTask(id);
                Console.WriteLine(success
                    ? "Görev durumu değiştirildi."
                    : "Görev bulunamadı.");
            }

            Pause();
        }

        private void RemoveTask()
        {
            Console.Clear();
            Console.Write("Silinecek görev ID: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool success = _taskService.RemoveTask(id);
                Console.WriteLine(success
                    ? "Görev silindi."
                    : "Görev bulunamadı.");
            }

            Pause();
        }

        private void Pause()
        {
            Console.WriteLine("\nDevam etmek için bir tuşa bas...");
            Console.ReadKey();
        }
    }
}
