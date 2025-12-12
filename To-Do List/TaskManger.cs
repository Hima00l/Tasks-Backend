using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List;

namespace To_Do_List
{
    public class TaskManger
    {
        private const string FilePath = "tasks.txt";
        private List<Item> Tasks = new List<Item>();

        public TaskManger()
        {
            Load();
        }

        private void Load()
        {
           // Tasks.Clear();
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Tasks.Add(new Item
                        {
                            Id = int.Parse(parts[0]),
                            Check = bool.Parse(parts[1]),
                            Title = parts[2]
                        });
                    }
                }
            }
        }
        private void Save()
        {
            var lines = Tasks.Select(t => $"{t.Id}|{t.Check}|{t.Title}");
            File.WriteAllLines(FilePath, lines);

        }
        public void Add(string title)
        {
            int newId = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1;
            Tasks.Add(new Item
            {
                Id = newId,
                Title = title,
                Check = false
            });
            Save();
            Console.WriteLine("Task Added");
        }
        public void List()
        {
            Console.WriteLine("=== List Tasks ===");
            foreach (var task in Tasks)
            {
                Console.WriteLine($"{task.Id}. [{(task.Check ? "√" : " ")}] {task.Title}");
            }
        }
        public void Done(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Check = true;
                Save();
                Console.WriteLine("Task Marked as Done");
            }
            else
            {
                Console.WriteLine("Task Not Found");
            }
        }

    }
}
/*var newItem = new Item
{
    Id = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1,
    Title = title,
    Check = false
};
Tasks.Add(newItem);
Save();*/
