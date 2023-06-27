using TaskManager.Enums;

namespace TaskManager.Models;

public class TaskModel
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DeadLine { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}
