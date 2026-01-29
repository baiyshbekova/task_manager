class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Добавить задачу");
            Console.WriteLine("2. Показать задачи");
            Console.WriteLine("3. Отметить как выполненную");
            Console.WriteLine("4. Удалить задачу");
            Console.WriteLine("5. Выход");
            Console.Write("Выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите текст задачи: ");
                    string title = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(title))
                        manager.AddTask(title);
                    else
                        Console.WriteLine("Пустая задача недопустима.");
                    break;

                case "2":
                    manager.ShowTasks();
                    break;

                case "3":
                    Console.Write("Введите ID задачи: ");
                    if (int.TryParse(Console.ReadLine(), out int complete_id))
                        manager.CompleteTask(complete_id);
                    else
                        Console.WriteLine("Неверный ввод.");
                    break;

                case "4":
                    Console.Write("Введите ID задачи: ");
                    if (int.TryParse(Console.ReadLine(), out int delete_id))
                        manager.DeleteTask(delete_id);
                    else
                        Console.WriteLine("Неверный ввод.");
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Неизвестная команда.");
                    break;
            }
        }
    }
}