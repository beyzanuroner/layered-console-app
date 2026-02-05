using LayeredConsoleApp.Application;
using LayeredConsoleApp.Infrastructure;
using LayeredConsoleApp.Presentation;

class Program
{
    static void Main(string[] args)
    {
        // Infrastructure
        var repository = new TaskRepository();

        // Application
        var service = new TaskService(repository);

        // Presentation
        var ui = new ConsoleUI(service);

        ui.Run();
    }
}
