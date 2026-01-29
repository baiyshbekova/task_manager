using System.Text.Json;

public class TaskManager
{
    private List<TaskItem> tasks;
    private const string file_name = "tasks.json";

    public TaskManager()
    {
        Load();
    }

    public void AddTask(string title)
    {
        int id = tasks.Count == 0 ? 1 : tasks[^1].Id + 1;
        tasks.Add(new TaskItem(id, title));
        Save();
    }

    public void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "[✔]" : "[ ]";
            Console.WriteLine($"{task.Id}. {status} {task.Title}");
        }
    }

    public void CompleteTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("Задача не найдена.");
            return;
        }

        task.IsCompleted = true;
        Save();
    }

    public void DeleteTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
        {
            Console.WriteLine("Задача не найдена.");
            return;
        }

        tasks.Remove(task);
        Save();
    }

    private void Save()
    {
        string json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(file_name, json);
    }

    private void Load()
    {
        if (!File.Exists(file_name))
        {
            tasks = new List<TaskItem>();
            return;
        }

        string json = File.ReadAllText(file_name);
        tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }
}