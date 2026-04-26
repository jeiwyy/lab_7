internal class Files
{ 
    public static string CheckFileTxt()
    {
        Console.Write("Введите имя файла: ");
        string path = Console.ReadLine();
        string resPath = "/home/jeiw/YP/Csharp/lab_7/";
        bool isCorrect = false;
        while (!isCorrect)
        {
            if (path.EndsWith(".txt"))
            {
                resPath += path;
                if (!File.Exists(resPath))
                {
                    File.WriteAllText(resPath, "");
                }
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Ошибка! Недопустимое расширение файла");
                Console.Write("Введите имя файла: ");
                path = Console.ReadLine();
            }
        }
        return resPath;
    }

    public static string GenerateFileFirst()
    {
        string path = CheckFileTxt();
        bool isCorrect = false;
        int count = 0;
        string input = "";
        while (!isCorrect)
        {
            Console.Write("Введите кол-во элементов: ");
            input = Console.ReadLine();
            isCorrect = int.TryParse(input, out count);
            if (!isCorrect || count <= 0)
            {
                Console.WriteLine("Ошибка ввода!");
                isCorrect = false;
            }
        }
        Random rnd = new Random();
        input = "";
        for (int i = 0; i < count; i++)
        {
            input += rnd.Next(-50,51).ToString() + "\n";
        }
        File.WriteAllText(path, input);
        return path;
    }

    public static bool TaskFirst(string path)
    {
        string[] nums = File.ReadAllLines(path);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == "0")
            {
                return true;
            }
        }
        return false;
    }

    public static string GenerateFileSecdond()
    {
        string path = CheckFileTxt();
        bool isCorrect = false;
        int count = 0;
        string input = "";
        while (!isCorrect)
        {
            Console.Write("Введите кол-во элементов: ");
            input = Console.ReadLine();
            isCorrect = int.TryParse(input, out count);
            if (!isCorrect || count <= 0)
            {
                Console.WriteLine("Ошибка ввода!");
                isCorrect = false;
            }
        }
        Random rnd = new Random();
        input = "";
        for (int i = 0; i < count; i++)
        {
            input += rnd.Next(0, 100).ToString() + " ";
        }
        File.WriteAllText(path, input);
        return path;
    }

    public static int TaskSecond(string path)
    {
        string allFile = File.ReadAllText(path);
        string[] nums = allFile.Split(' ');
        int max = Int32.MinValue;
        int num = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != "")
            {
                num = Convert.ToInt32(nums[i]);
                if (num >= max)
                {
                    max = num;
                }
            }
        }

        return max;
    }

    public static string GenerateFileThird()
    {
        string path = CheckFileTxt();
        bool isCorrect = false;
        int count = 0;
        string input = "";
        while (!isCorrect)
        {
            Console.Write("Введите кол-во строк: ");
            input = Console.ReadLine();
            isCorrect = int.TryParse(input, out count);
            if (!isCorrect || count <= 0)
            {
                Console.WriteLine("Ошибка ввода!");
                isCorrect = false;
            }
        }
        char[] chars = "abcdefghijklmnopqrstuwxyz0123456789".ToCharArray();
        for (int i = 0; i < count; i++)
        {
            input += new string(Random.Shared.GetItems(chars, 6)) + "\n";
        }
        File.WriteAllText(path, input);
        return path;
    }

    public static string TaskThird(string path)
    {
        Console.WriteLine("Создание файла для вывода результата...");
        string resPath = CheckFileTxt();
        string[] lines = File.ReadAllLines(path);
        char compareChar = '0';
        string result = "";
        Console.Write("Введите символ с которым будут сравниваться строки: ");
        compareChar = Console.ReadLine()[0];
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].EndsWith(compareChar))
            {
                result += lines[i] + "\n";
            }
        }
        File.WriteAllText(resPath, result);
        return resPath;
    }

    public void GenerateFileFourth()
    {
        
    }

    public static void Print(string path)
    {
        string s = "Путь к файлу: " + path + "\nСодержание файла:\n";
        s += File.ReadAllText(path);
        Console.WriteLine(s);
    }
}