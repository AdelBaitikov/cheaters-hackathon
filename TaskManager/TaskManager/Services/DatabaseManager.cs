using TaskManager.Models;

namespace TaskManager.Services;

public class DatabaseManager
{
    public List<TaskModel> GetTasks()
    {
        return new List<TaskModel>()
        {
            new TaskModel()
            {
                Id = 1,
                Title = "Покормить кота",
                Description = "Феликс помирает с голоду.",
                DeadLine = DateTime.Now.AddHours(3),
                Priority = Enums.Priority.High,
                Status = Enums.Status.Planning,
            },
            new TaskModel()
            {
                Id = 2,
                Title = "Поесть самому",
                Description = "Мама приготовила борщик, надо кушать, а то пропадет...",
                DeadLine = DateTime.Now.AddHours(-1),
                Priority = Enums.Priority.Low,
                Status = Enums.Status.Complete,
            },
            new TaskModel()
            {
                Id = 3,
                Title = "Проснуться пораньше",
                Description = null,
                DeadLine = DateTime.Now.AddDays(3),
                Priority = Enums.Priority.Medium,
                Status = Enums.Status.Delayed,
            },
        };
    }
}
