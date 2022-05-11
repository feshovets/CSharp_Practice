using Program;

namespace Main
{
    public class Program
    {
        public static void Search(CustomCollection<Advertisement> conteiner)
        {
        }
        public static void Sort(CustomCollection<Advertisement> conteiner)
        {
            Console.WriteLine("Write field, you want sort to do");
            conteiner.Sort(Console.ReadLine());
            Console.WriteLine("Sorted");
            //conteiner.write_to_file();
        }

        public static void Add(CustomCollection<Advertisement> conteiner)
        {
            //
        }

        public static void Read_from_file(CustomCollection<Advertisement> conteiner)
        {
            conteiner.ReadJsonFile(@"C:\Users\Olgerd\source\repos\ProgaPractice\ProgaPractice\Data.json");
            Console.WriteLine("Reading complete.");
        }
        public static void Write_to_file(CustomCollection<Advertisement> conteiner)
        {
            conteiner.WriteToFile(@"C:\Users\Olgerd\source\repos\ProgaPractice\ProgaPractice\Output.json");
        }
        public static void Edit(CustomCollection<Advertisement> conteiner)
        {
           //
        }

        public static void Print(CustomCollection<Advertisement> conteiner)
        {
            conteiner.PrintContainer();
        }

        public static void Clear(CustomCollection<Advertisement> conteiner)
        {
            conteiner.Clear();
            //conteiner.write_to_file();
            Console.WriteLine("Clear");
        }

        public static void Remove(CustomCollection<Advertisement> conteiner)
        {
            Console.WriteLine("write object id");
            int id = int.Parse(Console.ReadLine());

            conteiner.Remove(id);
            //conteiner.write_to_file();

            Console.WriteLine($"Remove object with id {id} removed");
        }

        private static int index = 0;

        private static void Main(string[] args)
        {
            var Collection = new CustomCollection<Advertisement>();
            List<string> menuItems = new List<string>() {
                "Search",
                "Sort",
                "Add",
                "Read from file",
                "Write to file",
                "Edit",
                "Print",
                "Clear",
                "Remove",
                "Exit"
            };

            Console.CursorVisible = false;
            while (true)
            {
                string selectedMenuItem = DrawMenu(menuItems);
                if (selectedMenuItem == "Search")
                {
                    Search(Collection);
                }
                else if (selectedMenuItem == "Sort")
                {
                    Console.Clear();
                    Sort(Collection);
                }
                else if (selectedMenuItem == "Add")
                {
                    Console.Clear();
                    Add(Collection);
                }
                else if (selectedMenuItem == "Read from file")
                {
                    Console.Clear();
                    Read_from_file(Collection);
                }
                else if (selectedMenuItem == "Edit")
                {
                    Console.Clear();
                    Edit(Collection);
                }
                else if (selectedMenuItem == "Print")
                {
                    Console.Clear();
                    Print(Collection);
                }
                else if (selectedMenuItem == "Clear")
                {
                    Console.Clear();
                    Clear(Collection);
                }
                else if (selectedMenuItem == "Write to file")
                {
                    Console.Clear();
                    Write_to_file(Collection);
                }
                else if (selectedMenuItem == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }
        private static string DrawMenu(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            ConsoleKeyInfo ckey = Console.ReadKey();

            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (index == items.Count - 1)
                    index = 0;
                else
                    index++;
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (index <= 0)
                    index = items.Count - 1;
                else 
                    index--;
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[index];
            }
            else
            {
                return "";
            }

            Console.Clear();
            return "";
        }
    }
}
