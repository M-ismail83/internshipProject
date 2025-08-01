public class ToDoItem
{
    public string? Title { get; set; }
    public bool isDone { get; set; }
    public Progress Status { get; set; }
}

public enum Progress
{
    ToDo,
    InProgress,
    Done
}