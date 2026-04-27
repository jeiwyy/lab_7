using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

internal class Collections
{
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

    private static List<string> GenerateList()
    {
        int count = GetCount();
        char[] chars = "abcdefghijklmnopqrstuwxyz".ToCharArray();
        List<string> result = [];
        for (int i = 0; i < count; i++)
        {
            result.Add(new string(Random.Shared.GetItems(chars, 3)));
        }
        Console.WriteLine("Получившийся список:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(result[i]);
        }
        return result;
    }
    public static List<string> TaskSixth()
    {
        List<string> ourList = GenerateList();
        List<string> resList = [];
        Console.Write("Введите элемент E: ");
        string e = Console.ReadLine();
        resList.Add(ourList[0]);
        for (int i = 1; i < ourList.Count; i++)
        {
            if (!(ourList[i-1] == e))
            {
                resList.Add(ourList[i]);
            }
        }
        Console.WriteLine("Результирующий список:");
        for (int i = 0; i < resList.Count; i++)
        {
            Console.WriteLine(resList[i]);
        }
        return resList;
    }

    private static LinkedList<string> GenerateLinkedList()
    {
        int count = GetCount();
        char[] chars = "abcdewxyz".ToCharArray();
        LinkedList<string> result = [];
        for (int i = 0; i < count; i++)
        {
            result.AddLast(new string(Random.Shared.GetItems(chars, 1)));
        }
        Console.WriteLine("Получившийся список:");
        foreach (string item in result)
        {
            Console.WriteLine(item);
        }
        return result;
    }

    public static bool TaskSeventh()
    {
        LinkedList<string> ourList = GenerateLinkedList();
        LinkedListNode<string> current = ourList.First;
        bool end = false;
        while (!end)
        {   
            if (current.Next == null)
            {
                if (current.Value == ourList.First.Value)
                {
                    return true;
                }
                end = true;
            }
            else if (current.Value == current.Next.Value)
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }
    public static void TaskEighth()
    {
        HashSet<string> allCountries = new HashSet<string> 
        { 
            "Россия", "Германия", "Финляндия", "Нидерланды"
        };

        List<HashSet<string>> tourists = new List<HashSet<string>>
        {
            new HashSet<string> { "Россия" },
            new HashSet<string> { "Россия", "Финляндия" },
            new HashSet<string> { "Россия", "Финляндия", "Нидерланды" },
        };

        HashSet<string> visitAll = new HashSet<string>(tourists[0]);
        foreach (var visit in tourists)
        {
            visitAll.IntersectWith(visit); 
        }
        HashSet<string> visitSome = new HashSet<string>();
        foreach (var visit in tourists)
        {
            visitSome.UnionWith(visit); 
        }
        HashSet<string> visitNone = new HashSet<string>(allCountries);
        foreach (var visit in tourists)
        {
            visitNone.ExceptWith(visit);
        }
        Console.WriteLine("Посетили все:       " + string.Join(", ", visitAll));
        Console.WriteLine("Посетили некоторые: " + string.Join(", ", visitSome));
        Console.WriteLine("Никто не посетил:   " + string.Join(", ", visitNone));
    }
    public static void TaskNinth()
    {
        HashSet<char> deaf = new HashSet<char>
        {
            'к', 'п', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ'
        };
        HashSet<char> firstSeen = new HashSet<char>();
        HashSet<char> multipleSeen = new HashSet<char>();
        HashSet<char> wordChars = [];
        HashSet<char> repeats = [];

        string file = Files.CheckFileTxt();
        string text = File.ReadAllText(file).ToLower();
        List<string> words = new List<string>(text.Split(' '));
        foreach (string word in words)
        {
            wordChars = new HashSet<char>(word);
            wordChars.IntersectWith(deaf);
            repeats = new HashSet<char>(wordChars);
            repeats.IntersectWith(firstSeen); 
            multipleSeen.UnionWith(repeats);
            firstSeen.UnionWith(wordChars);
        }
        HashSet<char> exactlyOnce = new HashSet<char>(firstSeen);
        exactlyOnce.ExceptWith(multipleSeen);
        deaf.ExceptWith(exactlyOnce);
        Console.WriteLine("Результат:");
        foreach (char c in deaf)
        {
            Console.Write(c + " ");
        }
    }

    public static void TaskTenth()
    {
        string file = Files.CheckFileTxt();
        string[] text = File.ReadAllLines(file);
        SortedList<string, int[]> entrant = 
            new SortedList<string, int[]>();
        foreach (string rawValue in text)
        {
            string[] value = rawValue.Split(' ');
            if (value.Count() > 3)
            {
                string applicantName = value[0] + " " +value[1];
                int firExam = -1;
                int secExam = -1;
                bool isCorrect = int.TryParse(value[2], out firExam);
                if (!isCorrect || firExam < 0 || firExam > 100)
                {
                    Console.WriteLine("Ошибка баллов у " + applicantName);
                    firExam = -1;
                }
                isCorrect = int.TryParse(value[3], out secExam);
                if (!isCorrect || secExam < 0 || secExam > 100)
                {
                    Console.WriteLine("Ошибка баллов у " + applicantName);
                    secExam = -1;
                }
                if (firExam != -1 && secExam != -1)
                {
                    entrant.Add(applicantName, [firExam, secExam]);
                }
            }
            else
            {
                Console.WriteLine("Ошибка данных в строке: " + rawValue);
            }
            
        }

        for (int i = 0; i < entrant.Count; i++)
        {
            if (entrant.Values[i][0] >= 30 && entrant.Values[i][1] >= 30)
            {
                Console.WriteLine(entrant.Keys[i]);
            }
        }
    }

}