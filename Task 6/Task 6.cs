using System;
using System.Linq;

namespace Task_10
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            string[] figures = { "ладья", "слон", "король", "ферзь" };

            while (true)
            {
                char x1, y1, x2, y2;
                string figure;

                // Ввод фигуры и проверка её валидности
                do
                {
                    Console.Write("Введите фигуру: ");
                    figure = Console.ReadLine().Trim().ToLower();

                    if (string.IsNullOrWhiteSpace(figure))
                    {
                        Console.WriteLine("Вы ввели пустую строку!");
                    }
                    else if (!figures.Contains(figure))
                    {
                        Console.WriteLine("Такой фигуры не существует");
                        Console.Write("Вот список существующих фигур: ");
                        foreach (var f in figures)
                        {
                            Console.Write(f + ", ");
                        }
                        Console.WriteLine();
                    }
                } while (!figures.Contains(figure) || string.IsNullOrWhiteSpace(figure));

                // Генерация случайных координат для первого поля
                x1 = (char)('a' + rnd.Next(8));
                y1 = (char)('1' + rnd.Next(8));

                // Генерация случайных координат для второго поля, удовлетворяющих условиям
                do
                {
                    x2 = (char)('a' + rnd.Next(8));
                    y2 = (char)('1' + rnd.Next(8));
                } while (!CheckSafety(figure, x1, y1, x2, y2));

                // Определение случайного типа фигуры для второго поля
                string randomFigure = GetRandomFigure(figures);

                // Отрисовка шахматной доски с указанием фигур на полях
                DrawChessboard(x1, y1, x2, y2, figure, randomFigure);
            }
        }

        // Метод для определения случайной фигуры на втором поле
        static string GetRandomFigure(string[] figures)
        {
            return figures[rnd.Next(figures.Length)];
        }

        // Метод для проверки условий, соответствующих типу фигуры на первом поле
        static bool CheckSafety(string figure, char x1, char y1, char x2, char y2)
        {
            switch (figure)
            {
                case "ладья":
                    return x1 != x2 && y1 != y2;
                case "слон":
                    return Math.Abs(x1 - x2) != Math.Abs(y1 - y2);
                case "король":
                    return Math.Abs(x1 - x2) <= 1 && Math.Abs(y1 - y2) <= 1;
                case "ферзь":
                    return x1 != x2 && y1 != y2 && Math.Abs(x1 - x2) != Math.Abs(y1 - y2);
                default:
                    return true;
            }
        }

        // Метод для отрисовки шахматной доски с указанием фигур на полях
        static void DrawChessboard(char x1, char y1, char x2, char y2, string figure1, string figure2)
        {
            Console.WriteLine("Первая фигура: " + figure1 + ", Вторая фигура: " + figure2);
            Console.WriteLine("   a b c d e f g h");

            for (int i = 8; i >= 1; i--)
            {
                Console.Write($" {i} ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.ResetColor();

                    if (i == y1 - '0' && j == x1 - 'a' + 1)
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    else if (i == y2 - '0' && j == x2 - 'a' + 1)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    if ((i == y1 - '0' && j == x1 - 'a' + 1))
                        Console.Write("1" + figure1.Substring(0, 1).ToUpper());
                    else if ((i == y2 - '0' && j == x2 - 'a' + 1))
                        Console.Write("2" + figure2.Substring(0, 1).ToUpper());
                    else
                        Console.Write("  ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }

            bool isValidPosition = CheckSafety(figure1, x1, y1, x2, y2);
            Console.ForegroundColor = isValidPosition ? ConsoleColor.Green : ConsoleColor.Red;

            if (isValidPosition)
            {
                Console.WriteLine($"Фигура {figure1} на поле {x2}{y2} не угрожает фигуре {figure2}");
            }
            else
            {
                Console.WriteLine($"Фигура {figure1} на поле {x2}{y2} угрожает фигуре {figure2}");
            }

            Console.ResetColor();
        }
    }
}
