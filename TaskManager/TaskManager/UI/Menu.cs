namespace TaskManager.UI;

public class Menu
{
    private Option _selected;
    private readonly List<Option> _options;
    private readonly int _maxOptionLength;

    public Menu(List<Option> options)
    {
        _options = options;
        _selected = options.FirstOrDefault()
            ?? throw new Exception("Меню должно содержать хотя бы одну опцию.");
        _maxOptionLength = options.MaxBy(o => o.Title.Length)!.Title.Length;
    }

    public void Draw(string? header = null, string? footer = null)
    {
        Console.Clear();

        if (header != null)
            Console.WriteLine(header);

        foreach (var option in _options)
        {
            if (option == _selected)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            var optionTitle = option.Title
                .PadRight(_maxOptionLength + 2)
                .PadLeft(_maxOptionLength + 4);

            Console.Write(optionTitle);
            Console.ResetColor();
            Console.WriteLine();
        }

        if (footer != null)
            Console.WriteLine(footer);
    }

    public void MoveOption(int step)
    {
        var index = _options.IndexOf(_selected) + step;

        if (index < 0) return;
        if (index > _options.Count - 1) return;

        _selected = _options[index];
    }

    public void ActivateOption() => _selected.OnSelect();
}
