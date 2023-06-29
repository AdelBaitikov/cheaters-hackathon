namespace TaskManager.UI;

public class Option
{
    public string Title { get; set; } = string.Empty;
    public Action OnSelect { get; set; } = () => { };
}
