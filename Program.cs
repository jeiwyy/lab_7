using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int option = 1;
        bool isCorrect = false;
        string input = "";
        string file = "";
        while (option != 0)
        {
            while (!isCorrect)
            {
                Console.Write("\nВыберите задание(1-10, 0 - выход): ");
                input = Console.ReadLine();
                isCorrect = int.TryParse(input, out option);
                if (!isCorrect || option < 0 || option > 10)
                {
                    Console.WriteLine("Ошибка ввода!");
                    isCorrect = false;
                }
            }
            isCorrect = false;

            if (option == 1)
            {
                file = Files.GenerateFileFirst();
                Files.Print(file);
                if (Files.TaskFirst(file))
                {
                    Console.WriteLine("В файле содержится ноль");
                }
                else
                {
                    Console.WriteLine("В файле нету нуля");
                }
            }
            if (option == 2)
            {
                file = Files.GenerateFileSecdond();
                Files.Print(file);
                Console.Write("Максимальное число в файле: " + 
                    Files.TaskSecond(file));
            }
            if (option == 3)
            {
                Console.Write("Создать случайный файл? (y/n): ");
                string choice = Console.ReadLine();
                if (choice[0] == 'n')
                {
                    file = Files.CheckFileTxt();
                }
                else
                {
                    file = Files.GenerateFileThird();
                }
                Files.Print(file);
                string resFile = Files.TaskThird(file);
                Console.WriteLine("Результат: ");
                Files.Print(resFile);
            }
            if (option == 4)
            {
                int count = Files.GetCount();
                file = Files.GenerateFileFourth(count);
                Files.Print(file, count);
                Console.WriteLine("Пар противоположных чисел: " + 
                    Files.TaskFourth(file, count));
            }
            if (option == 5)
            {
                file = Files.GenerateFileFifth();
                Files.PrintXml(file);
                Files.TaskFifth(file);
            }
            if (option == 6)
            {
                Collections.TaskSixth();
            }
            if (option == 7)
            {
                if (Collections.TaskSeventh())
                {
                    Console.WriteLine("Пара равных и идущих по порядку " 
                        + "элементов существует");
                }
                else
                {
                    Console.WriteLine("Пара равных и идущих по порядку " 
                        + "элементов не существует");
                }
            }
            if (option == 8)
            {
                Collections.TaskEighth();
            }
            if (option == 9)
            {
                Collections.TaskNinth();
            }
            if (option == 10)
            {
                Collections.TaskTenth();
            }
        }
        
    }
}