using System;
using System.Text.RegularExpressions;

namespace LaboratoryWork3
{
    class Program
    {
        private static readonly Random Rnd = new Random();

        private static readonly string[] BaseKeywords = { "static", "void", "if", "else" };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[,] matrix = new int[0, 0];
            int[][] jaggedArray = new int[0][];
            bool isRunning = true;

            do
            {
                Console.WriteLine("=== ГЛАВНОЕ МЕНЮ ===");
                Console.WriteLine("1. Работа с двумерными массивами");
                Console.WriteLine("2. Работа с рваными массивами");
                Console.WriteLine("3. Работа со строками");
                Console.WriteLine("4. Выход");

                int mainMenuChoice = ReadIntNumber("Выберите пункт меню (1-4): ", 1, 4);

                switch (mainMenuChoice)
                {
                    case 1:
                        RunMatrixSubMenu(ref matrix);
                        break;
                    case 2:
                        RunJaggedSubMenu(ref jaggedArray);
                        break;
                    case 3:
                        RunStringSubMenu();
                        break;
                    case 4:
                        isRunning = false;
                        Console.WriteLine("Программа завершена.");
                        break;
                }
                if (isRunning)
                {
                    Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в главное меню...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (isRunning);
        }

        static void RunMatrixSubMenu(ref int[,] matrix)
        {
            Console.Clear();
            Console.WriteLine("--- Подменю: Двумерные массивы ---");
            Console.WriteLine("1. Создать матрицу случайными числами (ДСЧ)");
            Console.WriteLine("2. Создать матрицу вручную с клавиатуры");
            Console.WriteLine("3. Удалить все четные столбцы");
            Console.WriteLine("4. Напечатать текущую матрицу");
            Console.WriteLine("5. Назад");

            int choice = ReadIntNumber("Выберите действие (1-5): ", 1, 5);
            switch (choice)
            {
                case 1:
                    int rows = ReadIntNumber("Введите количество строк: ", 1, 100);
                    int cols = ReadIntNumber("Введите количество столбцов: ", 1, 100);
                    matrix = CreateMatrixRandom(rows, cols);
                    Console.WriteLine("Матрица успешно создана с помощью ДСЧ.");
                    PrintMatrix(matrix);
                    break;
                case 2:
                    int mRows = ReadIntNumber("Введите количество строк: ", 1, 100);
                    int mCols = ReadIntNumber("Введите количество столбцов: ", 1, 100);
                    matrix = CreateMatrixManual(mRows, mCols);
                    Console.WriteLine("Матрица успешно введена.");
                    PrintMatrix(matrix);
                    break;
                case 3:
                    if (matrix == null || matrix.Length == 0)
                    {
                        Console.WriteLine("Ошибка: Массив пустой! Удаление невозможно.");
                        return;
                    }
                    matrix = RemoveEvenColumns(matrix);
                    Console.WriteLine("Все четные столбцы удалены.");
                    PrintMatrix(matrix);
                    break;
                case 4:
                    PrintMatrix(matrix);
                    break;
            }
        }

        static void RunJaggedSubMenu(ref int[][] jaggedArray)
        {
            Console.Clear();
            Console.WriteLine("--- Подменю: Рваные массивы ---");
            Console.WriteLine("1. Создать рваный массив (ДСЧ)");
            Console.WriteLine("2. Создать рваный массив вручную");
            Console.WriteLine("3. Добавить K строк, начиная с номера N");
            Console.WriteLine("4. Напечатать текущий рваный массив");
            Console.WriteLine("5. Назад");

            int choice = ReadIntNumber("Выберите действие (1-5): ", 1, 5);
            switch (choice)
            {
                case 1:
                    int rows = ReadIntNumber("Введите количество строк массива: ", 1, 100);
                    jaggedArray = CreateJaggedRandom(rows);
                    Console.WriteLine("Рваный массив успешно создан.");
                    PrintJagged(jaggedArray);
                    break;
                case 2:
                    int mRows = ReadIntNumber("Введите количество строк массива: ", 1, 100);
                    jaggedArray = CreateJaggedManual(mRows);
                    Console.WriteLine("Рваный массив успешно введен.");
                    PrintJagged(jaggedArray);
                    break;
                case 3:
                    if (jaggedArray == null || jaggedArray.Length == 0)
                    {
                        Console.WriteLine("Ошибка: Массив пустой! Сначала сформируйте его.");
                        return;
                    }
                    int k = ReadIntNumber("Введите количество добавляемых строк (K): ", 1, 50);
                    int n = ReadIntNumber($"Введите номер позиции N для вставки (1-{jaggedArray.Length + 1}): ", 1, jaggedArray.Length + 1);
                    
                    Console.WriteLine("Как заполнить новые строки?\n1. С помощью ДСЧ\n2. Вручную");
                    int mode = ReadIntNumber("Ваш выбор: ", 1, 2);
                    int[][] extraRows = (mode == 1) ? CreateJaggedRandom(k) : CreateJaggedManual(k);

                    jaggedArray = AddRowsToJagged(jaggedArray, n - 1, extraRows);
                    Console.WriteLine("Строки успешно добавлены.");
                    PrintJagged(jaggedArray);
                    break;
                case 4:
                    PrintJagged(jaggedArray);
                    break;
            }
        }

        static void RunStringSubMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Подменю: Работа со строками ---");
            Console.WriteLine("1. Ввести строку с клавиатуры");
            Console.WriteLine("2. Запустить готовый тестовый пример");
            Console.WriteLine("3. Назад");

            int choice = ReadIntNumber("Выберите действие (1-3): ", 1, 3);
            string? inputStr = "";

            if (choice == 1)
            {
                Console.WriteLine("Введите строку (разделители пробелы и знаки , ; : . ! ?):");
                inputStr = Console.ReadLine();
            }
            else if (choice == 2)
            {
                inputStr = "static void PrintUpper string_info12346: WriteLine ToUpper info, 1234info. if x>0 then sign=1; else if x<0 sign=-1; else sign=0.";
                Console.WriteLine($"Тестовая строка:\n\"{inputStr}\"");
            }
            else return;

            if (string.IsNullOrEmpty(inputStr) || string.IsNullOrEmpty(inputStr.Trim()))
            {
                Console.WriteLine("Ошибка: Введена пустая строка.");
                return;
            }

            CountKeywords(inputStr);
        }
        public static int[,] RemoveEvenColumns(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int oldCols = matrix.GetLength(1);
            int newCols = oldCols - (oldCols / 2);

            int[,] result = new int[rows, newCols];

            for (int i = 0; i < rows; i++)
            {
                int currentNewCol = 0;
                for (int j = 0; j < oldCols; j++)
                {
                    if ((j + 1) % 2 != 0)
                    {
                        result[i, currentNewCol] = matrix[i, j];
                        currentNewCol++;
                    }
                }
            }
            return result;
        }

        public static int[][] AddRowsToJagged(int[][] source, int indexN, int[][]? newRows = null)
        {
            if (newRows == null) return source;

            int[][] result = new int[source.Length + newRows.Length][];

            for (int i = 0; i < indexN; i++)
            {
                result[i] = source[i];
            }

            for (int i = 0; i < newRows.Length; i++)
            {
                result[indexN + i] = newRows[i];
            }

            for (int i = indexN; i < source.Length; i++)
            {
                result[i + newRows.Length] = source[i];
            }

            return result;
        }

        public static void CountKeywords(string text)
        {
            Console.WriteLine("\nРезультат:");
            bool keywordsFound = false;

            foreach (string keyword in BaseKeywords)
            {
                string pattern = @"\b" + Regex.Escape(keyword) + @"\b";
                MatchCollection matches = Regex.Matches(text, pattern);

                if (matches.Count > 0)
                {
                    Console.WriteLine($"{keyword} – {matches.Count}");
                    keywordsFound = true;
                }
            }

            if (!keywordsFound)
            {
                Console.WriteLine("Ключевые слова C# не найдены.");
            }
        }
        static int ReadIntNumber(string message, int left, int right)
        {
            int number = 0;
            bool isInputOk = false;
            do
            {
                Console.Write(message);
                try
                {
                    string input = Console.ReadLine() ?? "";
                    number = Convert.ToInt32(input);
                    if (number >= left && number <= right)
                    {
                        isInputOk = true;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка: Число должно быть в диапазоне от {left} до {right}!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Неверно введено число! Допускаются только целые цифры.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: Введенное число слишком велико для типа int.");
                }
            } while (!isInputOk);

            return number;
        }

        static int[,] CreateMatrixRandom(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = Rnd.Next(0, 10);
            return matrix;
        }

        static int[,] CreateMatrixManual(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = ReadIntNumber($"Введите элемент [{i + 1},{j + 1}]: ", -100, 100);
            return matrix;
        }

        static int[][] CreateJaggedRandom(int rows)
        {
            int[][] jagged = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int cols = Rnd.Next(2, 7);
                jagged[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                    jagged[i][j] = Rnd.Next(0, 10);
            }
            return jagged;
        }

        static int[][] CreateJaggedManual(int rows)
        {
            int[][] jagged = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int cols = ReadIntNumber($"Введите количество столбцов для строки {i + 1}: ", 1, 20);
                jagged[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                    jagged[i][j] = ReadIntNumber($"Строка {i + 1}, элемент [{j + 1}]: ", -100, 100);
            }
            return jagged;
        }

        static void PrintMatrix(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                Console.WriteLine("Матрица пустая!");
                return;
            }
            Console.WriteLine("Вывод двумерного массива:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }
        }

        static void PrintJagged(int[][] jagged)
        {
            if (jagged == null || jagged.Length == 0)
            {
                Console.WriteLine("Рваный массив пустой!");
                return;
            }
            Console.WriteLine("Вывод рваного массива:");
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.Write($"Строка {i + 1} (длина {jagged[i].Length}): ");
                foreach (int item in jagged[i])
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }
    }
}
