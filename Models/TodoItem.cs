namespace cpsc_2650_tech_eval.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; } = "New Task";
    public bool IsComplete { get; set; }
}
