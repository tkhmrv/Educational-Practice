using System;

namespace Tasks_1_5
{
    internal class Coordinates
    {
        public char FigureX { get; set; }
        public char FigureY { get; set; }
        public char TargetX { get; set; }
        public char TargetY { get; set; }


        internal static Coordinates CoordinatesLogic(string FigureName)
        {
            Coordinates coordinates = new Coordinates();

            while (true)
            {
                if (FigureName == "поля")
                {
                    Console.Write($"Введите координаты первого поля x1y1 и координаты второго поля x2y2: ");
                }
                else
                {
                    Console.Write($"Введите координаты фигуры {FigureName} x1y1 и координаты цели x2y2: ");
                }

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                string[] Coordinates = input.Split(' ');

                if (Coordinates.Length != 2 || Coordinates[0].Length != 2 || Coordinates[1].Length != 2)
                {
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                coordinates.FigureX = Coordinates[0][0];
                coordinates.FigureY = Coordinates[0][1];
                coordinates.TargetX = Coordinates[1][0];
                coordinates.TargetY = Coordinates[1][1];

                if (!IsValidCoordinate(coordinates.FigureX, coordinates.FigureY) || !IsValidCoordinate(coordinates.TargetX, coordinates.TargetY))
                {
                    Console.WriteLine("Вы ввели некорректные координаты");
                    continue;
                }

                return coordinates;
            }
        }

        static bool IsValidCoordinate(char x, char y)
        {
            return x >= 'a' && x <= 'h' && y >= '1' && y <= '8';
        }
    }
}
