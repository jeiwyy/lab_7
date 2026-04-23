using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int option = 1;
        bool isCorrect = false;
        string input = "";
        string fileName = "";
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
                Console.Write("Введите имя файла:");
                fileName = Console.ReadLine();
                Files file = new Files(fileName);
                file.GenerateFileFirst();
                Console.WriteLine(file);
                Console.Write(file.TaskFirst());
            }
            if (option == 2)
            {
                Console.Write("Введите имя файла:");
                fileName = Console.ReadLine();
                Files file = new Files(fileName);
                file.GenerateFileSecdond();
                Console.WriteLine(file);
                Console.Write(file.TaskSecond());
            }
            if (option == 3)
            {
                string choice = "";
                Files file = new Files();
                Console.Write("Создать случайный файл? (y/n): ");
                choice = Console.ReadLine();
                if (choice == "y")
                {
                    file.GenerateFileThird();
                    Console.Write(file);
                }
                else
                {
                    Console.Write("Введите имя файла:");
                    fileName = Console.ReadLine();
                    file = new Files(fileName);
                }
                Console.Write("Введите название файла в который записать результат: ");
                fileName = Console.ReadLine();
                Files fileRes = new Files(fileName);
                file.TaskThird(fileRes);
                Console.WriteLine("Результат: ");
                Console.Write(fileRes);
            }
        }
        
    }
}