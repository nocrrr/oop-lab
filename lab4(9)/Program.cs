using System;

namespace LaboratoryWork9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ConsoleUI.PrintMessage("=== ЧАСТЬ 1: БАЗОВЫЙ КЛАСС TIME ===");
            Time t1 = new Time(); 
            Time t2 = new Time(2, 45);
            Time t3 = new Time(t2);

            ConsoleUI.PrintTime("Объект t1 (по умолчанию)", t1);
            ConsoleUI.PrintTime("Объект t2 (параметры)", t2);
            ConsoleUI.PrintTime("Объект t3 (копия t2)", t3);

            Time tMethod = t2.AddMinutes(30);
            Time tStatic = Time.AddMinutesStatic(t2, 80);

            ConsoleUI.PrintTime("t2 + 30 мин (метод класса)", tMethod);
            ConsoleUI.PrintTime("t2 + 80 мин (статический метод)", tStatic);
            ConsoleUI.PrintMessage($"Всего создано объектов Time: {Time.ObjectCount}\n");

            ConsoleUI.PrintMessage("=== ЧАСТЬ 2: ПЕРЕГРУЗКА ОПЕРАЦИЙ ===");
            Time tOp = new Time(1, 59);
            ConsoleUI.PrintTime("Исходное время tOp", tOp);

            tOp++;
            ConsoleUI.PrintTime("После tOp++", tOp);

            tOp--;
            ConsoleUI.PrintTime("После tOp--", tOp);

            int onlyHours = (int)tOp;
            bool isNotZero = tOp;
            ConsoleUI.PrintMessage($"Явное приведение (int)tOp: {onlyHours} ч.");
            ConsoleUI.PrintMessage($"Неявное приведение bool (часы и минуты != 0): {isNotZero}");

            Time tPlusRight = tOp + 25;
            Time tPlusLeft = 25 + tOp;
            Time tMinusRight = tOp - 70;
            Time tMinusLeft = 200 - tOp;

            ConsoleUI.PrintTime("tOp + 25", tPlusRight);
            ConsoleUI.PrintTime("25 + tOp", tPlusLeft);
            ConsoleUI.PrintTime("tOp - 70", tMinusRight);
            ConsoleUI.PrintTime("200 - tOp", tMinusLeft);

            ConsoleUI.PrintMessage("\n=== ЧАСТЬ 3: КОЛЛЕКЦИЯ TIMEARRAY ===");
            
            int randomSize = ConsoleUI.ReadInt("Введите размер случайного массива TimeArray (1-10): ", 1, 10);
            TimeArray randomArray = new TimeArray(randomSize);
            ConsoleUI.PrintTimeArray("Массив, заполненный ДСЧ", randomArray);

            Time avgRandom = CalculateAverageTime(randomArray);
            ConsoleUI.PrintTime("Среднее арифметическое случайного массива", avgRandom);

            int manualSize = ConsoleUI.ReadInt("\nВведите размер массива для ручного ввода (1-5): ", 1, 5);
            Time[] userElements = ConsoleUI.ReadTimeArrayFromConsole(manualSize);
            TimeArray manualArray = new TimeArray(userElements);
            ConsoleUI.PrintTimeArray("Массив, введенный с клавиатуры", manualArray);

            Time avgManual = CalculateAverageTime(manualArray);
            ConsoleUI.PrintTime("Среднее арифметическое ручного массива", avgManual);

            ConsoleUI.PrintMessage("\nПроверка защиты индексатора (обращение к индексу -1):");
            try
            {
                Time invalidAccess = manualArray[-1];
            }
            catch (ArgumentException ex)
            {
                ConsoleUI.PrintMessage($"Перехвачено ожидаемое исключение: {ex.Message}");
            }

            ConsoleUI.PrintMessage($"\nИтого создано объектов Time: {Time.ObjectCount}");
            ConsoleUI.PrintMessage($"Итого создано коллекций TimeArray: {TimeArray.CollectionCount}");
        }

        public static Time CalculateAverageTime(TimeArray collection)
        {
            if (collection == null || collection.Length == 0)
                return new Time(0, 0);

            int totalMinutesSum = 0;
            for (int i = 0; i < collection.Length; i++)
            {
                Time item = collection[i];
                totalMinutesSum += item.Hours * 60 + item.Minutes;
            }

            int averageMinutes = totalMinutesSum / collection.Length;
            return new Time(averageMinutes / 60, averageMinutes % 60);
        }
    }
}
