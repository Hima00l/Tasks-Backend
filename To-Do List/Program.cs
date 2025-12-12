namespace To_Do_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
           TaskManger taskManger = new TaskManger();
            while (true)
            {
                Console.WriteLine("Enter Command (Add , List , Done , Exit)");
                string command = Console.ReadLine() ?? "";
                string [] parts = command.Split(' ', 2);
                switch (parts[0].ToLower())
                {
                    case "add":
                        if (parts.Length > 1)
                        {
                            taskManger.Add(parts[1]);

                        }
                        else
                        {
                            Console.WriteLine("Please provide a task title.");
                        }
                        break;
                    case "list":
                        taskManger.List();
                        break;
                    case "done":
                        if (parts.Length > 1 && int.TryParse(parts[1], out int id))
                        {
                            taskManger.Done(id);
                        }
                        else
                        {
                            Console.WriteLine("Please provide a valid task ID.");
                        }
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Unknown command. Please use Add, List, Done, or Exit.");
                        break;

                }
            }
        }

    }
}
