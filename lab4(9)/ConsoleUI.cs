using System;

namespace LaboratoryWork9
{
    public static class ConsoleUI
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Ошибка ввода! Введите целое число от {min} до {max}.");
            }
        }

        public static Time ReadTimeFromConsole(string header)
        {
            Console.WriteLine(header);
            int hours = ReadInt("Введите часы (0-1000): ", 0, 1000);
            int minutes = ReadInt("Введите минуты (0-59): ", 0, 59);
            return new Time(hours, minutes);
        }

        public static Time[] ReadTimeArrayFromConsole(int size)
        {
            Time[] elements = new Time[size];
            for (int i = 0; i < size; i++)
            {
                elements[i] = ReadTimeFromConsole($"\n--- Ввод элемента №{i + 1} ---");
            }
            return elements;
        }

        public static void PrintTime(string label, Time t)
        {
            Console.WriteLine($"{label}: {t}");
        }

        public static void PrintTimeArray(string title, TimeArray collection)
        {
            Console.WriteLine($"\n=== {title} ===");
            if (collection.Length == 0)
            {
                Console.WriteLine("Коллекция пуста.");
                return;
            }

            for (int i = 0; i < collection.Length; i++)
            {
                Console.WriteLine($"[{i}] -> {collection[i]}");
            }
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
