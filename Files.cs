using System.Xml.Serialization;

public struct Luggage
{
    private string _name;
    private int _weight;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public int Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            _weight = value;
        }
    }
}

internal class Files
{
    public static string CheckFileTxt()
    {
        Console.Write("Введите имя файла: ");
        string path = Console.ReadLine();
        string resPath = "/home/jeiw/YP/Csharp/lab_7/files/";
        bool isCorrect = false;
        while (!isCorrect)
        {
            if (path.EndsWith(".txt"))
            {
                resPath += path;
                if (!File.Exists(resPath))
                {
                    File.Create(resPath).Dispose();
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
    public static string CheckFileBin()
    {
        Console.Write("Введите имя файла: ");
        string path = Console.ReadLine();
        string resPath = "/home/jeiw/YP/Csharp/lab_7/";
        bool isCorrect = false;
        while (!isCorrect)
        {
            if (path.EndsWith(".bin"))
            {
                resPath += path;
                if (!File.Exists(resPath))
                {
                    File.Create(resPath).Dispose();
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
    public static int GetCount()
    {
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
        return count;
    }

    public static string GenerateFileFirst()
    {
        string path = CheckFileTxt();
        int count = GetCount();
        Random rnd = new Random();
        string input = "";
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
        int count = GetCount();
        string input = "";
        Random rnd = new Random();
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
        string input = "";
        int count = GetCount();
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

    public static string GenerateFileFourth(int count)
    {
        string path = CheckFileBin();
        int input = 0;
        Random rnd = new Random();
        using (BinaryWriter writer =
            new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                input = rnd.Next(-20, 21);
                writer.Write(input);
            }
        }
        
        return path;
    }
    public static int TaskFourth(string path, int count)
    {
        int[] nums = new int[count + 1];
        int duplicates = 0;
        using (BinaryReader reader = 
                new BinaryReader(File.Open(path, FileMode.Open)))
        {
            for (int i = 0; i < count; i++)
            {
                nums[i] = reader.ReadInt32();
            }
        }
        for (int i = 0; i < count; i++)
        {
            if (nums.Contains(-nums[i]))
            {
                duplicates++;
            }
        }
        return duplicates / 2;
    }

    public static string GenerateFileFifth()
    {
        string path = CheckFileBin();
        int count = GetCount();
        Random rnd = new Random();
        string[] lugOpt = ["Чемодан", "Коробка", "Сумка", "Пакет", "Рюкзак"];
        Luggage[][] arrLuggage = new Luggage[count][];

        for (int i = 0; i < count; i++)
        {
            int lugCount = rnd.Next(1,5);
            arrLuggage[i] = new Luggage[lugCount];
            for (int j = 0; j < lugCount; j++)
            {
                arrLuggage[i][j] = new Luggage
                {
                    Name = lugOpt[rnd.Next(1,5)],
                    Weight = rnd.Next(1, 51)
                };
            }
        }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Luggage[][]));

        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            xmlSerializer.Serialize(fs, arrLuggage);
        }
        return path;
    }
    public static void TaskFifth(string path)
    {
        Luggage[][] arrLuggage;
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Luggage[][]));
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            arrLuggage = (Luggage[][])xmlSerializer.Deserialize(fs);

        }
        int min = 51;
        int max = 0;
        for (int i = 0; i < arrLuggage.Length; i++)
        {
            for (int j = 0; j < arrLuggage[i].Length; j++)
            {
                if (arrLuggage[i][j].Weight > max)
                {
                    max = arrLuggage[i][j].Weight;
                }
                if (arrLuggage[i][j].Weight < min)
                {
                    min = arrLuggage[i][j].Weight;
                }
            }
        }
        Console.WriteLine("\nРазница между самым большим и малеьнким " 
            + "багажом: " + (max - min));
    }

    public static void Print(string path)
    {
        string s = "Путь к файлу: " + path + "\nСодержание файла:\n";
        if (path.EndsWith(".txt") && File.Exists(path))
        {
            s += File.ReadAllText(path);
        }
        Console.WriteLine(s);
    }
    public static void Print(string path, int count)
    {
        string s = "Путь к файлу: " + path + "\nСодержание файла:\n";
        if (path.EndsWith(".bin") && File.Exists(path))
        {
            using (BinaryReader reader = 
                new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < count; i++)
                {
                    s += reader.ReadInt32() + "\n";
                }
            }
        }
        Console.WriteLine(s);
    }
    public static void PrintXml(string path)
    {
        Console.WriteLine("Путь к файлу: " + path + "\nСодержание файла:");
        if (path.EndsWith(".bin") && File.Exists(path))
        {
            Luggage[][] arrLuggage;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Luggage[][]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                arrLuggage = (Luggage[][])xmlSerializer.Deserialize(fs);

            }

            for (int i = 0; i < arrLuggage.Length; i++)
            {
                Console.WriteLine("Пассажир " + (i + 1) + ": ");
                for (int j = 0; j < arrLuggage[i].Length; j++)
                {
                    Console.WriteLine("  Название: "+arrLuggage[i][j].Name 
                        + "\tМасса: " + arrLuggage[i][j].Weight);
                }
            }

        }
    }
}