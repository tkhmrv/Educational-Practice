using System;
using System.Linq;

namespace Chess
{
    internal class Coordinates
    {
        public string FirstPiece { get; set; } // Название первой фигуры
        public string SecondPiece { get; set; } // Название второй фигуры (для задания 10)
        public char PieceX { get; set; } // Координата X первой фигуры
        public char PieceY { get; set; } // Координата Y первой фигуры
        public char TargetX { get; set; } // Координата X цели
        public char TargetY { get; set; } // Координата Y цели
        public char MoveX { get; set; } // Координата X для задания 9 (движение фигуры)
        public char MoveY { get; set; } // Координата Y для задания 9 (движение фигуры)

        // Tasks 1-5, 8
        internal static Coordinates CoordinatesBasic(string FigureName)
        {
            Coordinates coordinates = new Coordinates();

            while (true)
            {
                // Условие для 8 задания
                if (FigureName == "поля")
                {
                    Console.Write($"Введите координаты первого поля x1y1 и координаты второго поля x2y2: ");
                }
                else
                {
                    Console.Write($"Введите координаты фигуры {FigureName} x1y1 и координаты цели x2y2: ");
                }

                string input = Console.ReadLine();

                // Проверка ввода
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                string[] Coordinates = input.Split(' ');

                // Проверка длины координат
                if (Coordinates.Length != 2 || Coordinates[0].Length != 2 || Coordinates[1].Length != 2)
                {
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                coordinates.PieceX = Coordinates[0][0];
                coordinates.PieceY = Coordinates[0][1];
                coordinates.TargetX = Coordinates[1][0];
                coordinates.TargetY = Coordinates[1][1];

                // Проверка корректности методом
                if (!IsValidCoordinate(coordinates.PieceX, coordinates.PieceY) || !IsValidCoordinate(coordinates.TargetX, coordinates.TargetY))
                {
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                return coordinates;
            }
        }

        // Task 9
        internal static Coordinates CoordinatesAdvanced()
        {
            Coordinates coordinates = new Coordinates();

            while (true)
            {
                Console.Write("Введите исходные данные (белая_фигура x1y1 черная_фигура x2y2 точка_x3y3): ");
                string input = Console.ReadLine();

                // Проверка ввода
                if (input.Length == 0)
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                    continue;
                }

                string[] data = input.Trim().Split(' ');

                // Проверка длины координат
                if (data.Length != 5 || data[1].Length != 2 || data[3].Length != 2 || data[4].Length != 2)
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                    continue;
                }

                coordinates.FirstPiece = data[0];
                coordinates.PieceX = data[1][0];
                coordinates.PieceY = data[1][1];
                coordinates.SecondPiece = data[2];
                coordinates.TargetX = data[3][0];
                coordinates.TargetY = data[3][1];
                coordinates.MoveX = data[4][0];
                coordinates.MoveY = data[4][1];

                // Проверка корректности методом
                if (!IsValidCoordinate(coordinates.PieceX, coordinates.PieceY) || !IsValidCoordinate(coordinates.TargetX, coordinates.TargetY) || !IsValidCoordinate(coordinates.MoveX, coordinates.MoveY))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                return coordinates;
            }
        }

        // Task 10
        private static readonly Random rnd = new Random();
        internal static Coordinates CoordinatesRandom()
        {
            Coordinates coordinates = new Coordinates();

            string[] pieces = { "ладья", "слон", "король", "ферзь" };

            while (true)
            {
                do
                {
                    Console.Write("Введите первую фигуру: ");
                    coordinates.FirstPiece = Console.ReadLine().Trim().ToLower();

                    // Проверка ввода и сущестоввания фигуры
                    if (string.IsNullOrWhiteSpace(coordinates.FirstPiece))
                    {
                        Console.WriteLine("Вы ввели пустую строку!");
                    }
                    else if (!pieces.Contains(coordinates.FirstPiece))
                    {
                        Console.WriteLine("Такой фигуры не существует");
                        Console.Write("Введите фигуру из этого списка: ");
                        foreach (var f in pieces)
                        {
                            Console.Write(f + ", ");
                        }
                        Console.WriteLine();
                    }
                } while (!pieces.Contains(coordinates.FirstPiece) || string.IsNullOrWhiteSpace(coordinates.FirstPiece)); // Пока не будет введена существующая фигура

                // Рандомирзируем координаты первой фигуры
                coordinates.PieceX = (char)('a' + rnd.Next(8));
                coordinates.PieceY = (char)('1' + rnd.Next(8));

                // Рандомизируем координаты второй фигуры
                do
                {
                    coordinates.TargetX = (char)('a' + rnd.Next(8));
                    coordinates.TargetY = (char)('1' + rnd.Next(8));
                } while (!IsMovementRight(coordinates));

                coordinates.SecondPiece = pieces[rnd.Next(pieces.Length)];

                return coordinates;
            }
        }

        // Метод для проверки корректности координат
        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }

        // Метод для проверки корректности движения фигур в задании 9
        internal static bool IsMovementRight(Coordinates coordinates)
        {
            switch (coordinates.FirstPiece)
            {
                case "ладья":
                    return coordinates.PieceX != coordinates.TargetX && coordinates.PieceY != coordinates.TargetY;
                case "слон":
                    return Math.Abs(coordinates.PieceX - coordinates.TargetX) != Math.Abs(coordinates.PieceY - coordinates.TargetY);
                case "король":
                    return Math.Abs(coordinates.PieceX - coordinates.TargetX) <= 1 && Math.Abs(coordinates.PieceY - coordinates.TargetY) <= 1;
                case "ферзь":
                    return coordinates.PieceX != coordinates.TargetX && coordinates.PieceY != coordinates.TargetY && Math.Abs(coordinates.PieceX - coordinates.TargetX) != Math.Abs(coordinates.PieceY - coordinates.TargetY);
                default:
                    return true;
            }
        }
    }
}
