using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Globalization;

internal class Files
{
    private string _path;
    private string _type;
    
    public Files()
    {
        _path = "/home/jeiw/YP/Csharp/lab_7/File.txt";
        _type = "text";
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "");
        }
    }

    public Files(string _path)
    {
        this._path = "/home/jeiw/YP/Csharp/lab_7/";
        bool isCorrect = false;
        while (!isCorrect)
        {
            if (_path.EndsWith(".txt"))
            {
                this._path += _path;
                this._type = "text";
                if (!File.Exists(this._path))
                {
                    File.WriteAllText(this._path, "");
                }
                isCorrect = true;
            }
            else if (_path.EndsWith(".bin"))
            {
                this._path += _path;
                this._type = "binary";
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Ошибка! Недопустимое расширение файла");
                Console.Write("Введите новое имя файла: ");
                _path = Console.ReadLine();
            }
        }
    }

    public void GenerateFileFirst()
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
        Random rnd = new Random();
        input = "";
        int rndNum = 0;
        for (int i = 0; i < count; i++)
        {
            rndNum = rnd.Next(-50,51);
            input += rndNum.ToString() + "\n";
        }
        File.WriteAllText(Path, input);
    }

    public bool TaskFirst()
    {
        string[] nums = File.ReadAllLines(Path);

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == "0")
            {
                return true;
            }
        }
        return false;
    }

    public void GenerateFileSecdond()
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
        Random rnd = new Random();
        input = "";
        int rndNum = 0;
        for (int i = 0; i < count; i++)
        {
            rndNum = rnd.Next(0, 100);
            input += rndNum.ToString() + " ";
        }
        File.WriteAllText(Path, input);
    }

    public int TaskSecond()
    {
        string allFile = File.ReadAllText(Path);
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

    public void GenerateFileThird()
    {
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
        string rndStr = "";
        for (int i = 0; i < count; i++)
        {
            rndStr = new string(Random.Shared.GetItems(chars, 6)) + "\n";
            input += rndStr;
        }
        File.WriteAllText(Path, input);
    }

    public void TaskThird(Files fileRes)
    {
        string[] lines = File.ReadAllLines(Path);
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
        File.WriteAllText(fileRes.Path, result);
    }

    public string Path
    {
        get
        {
            return _path;
        }
    }

    public override string ToString()
    {
        string s = "Путь к файлу: " + Path + "\nСодержание файла:\n";
        s += File.ReadAllText(Path);
        return s;
    }
}