using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.UI;

public class AppUI
{
    private readonly DatabaseManager _database;

    private readonly Menu _main;

    public AppUI(DatabaseManager databaseManager)
    {
        _database = databaseManager;

        _main = new Menu(new List<Option>()
        {
            new Option() { Title = "Список задач", OnSelect = NavigateToTasks },
            new Option() { Title = "Добавить задачу" }
        });
    }

    public void Start() => Navigate(_main, header:
        "================================\n" +
        "Чтобы выйти, нажмите ESCAPE.\n" +
        "================================\n");

    private void NavigateToTasks()
    {
        var tasks = _database.GetTasks();
        var options = tasks.Select(t => new Option()
        {
            Title = $"#{t.Id} {t.Title}",
            OnSelect = () => NavigateToTask(t)
        }).ToList();

        var menu = new Menu(options);

        Navigate(menu);
    }

    private void NavigateToTask(TaskModel task)
    {
        var footer =
            "\n----------------------------" +
            "-----------------------------\n\n" +
            $"[ЗАДАЧА #{task.Id}]\n" +
            $"Дедлайн: {task.DeadLine:f}\n" +
            $"Статус: {task.Status}\n" +
            $"Приоритет: {task.Priority}\n" +
            $"Название: {task.Title}\n" +
            $"Описание: {task.Description}\n";

        var menu = new Menu(new List<Option>()
        {
            new Option() { Title = "Изменить задачу" },
            new Option() { Title = "Удалить задачу" },
        });

        Navigate(menu, footer: footer);
    }

    private void Navigate(Menu menu, string? header = null, string? footer = null)
    {
        var next = true;

        if (header == null)
        {
            header =
                "================================\n" +
                "Чтобы вернуться, нажмите ESCAPE.\n" +
                "================================\n";
        }

        do
        {
            menu.Draw(header, footer);

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape:
                    next = false;
                    break;
                case ConsoleKey.UpArrow:
                    menu.MoveOption(-1);
                    break;
                case ConsoleKey.DownArrow:
                    menu.MoveOption(1);
                    break;
                case ConsoleKey.Enter:
                    menu.ActivateOption();
                    break;
                default:
                    break;
            }

        } while (next);
    }
}