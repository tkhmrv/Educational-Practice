using System;

namespace Chess
{
    internal class Randomizer
    {
        // Метод для выполнения логики случайного выбора фигур и их позиций
        internal static void RandomLogic(Coordinates coordinates)
        {
            // Вывод информации о случайно выбранных фигурах
            Console.WriteLine("\nПервая фигура - " + coordinates.FirstPiece + ", Вторая фигура - " + coordinates.SecondPiece);

            // Проверка корректности позиции фигур
            bool isValidPosition = Coordinates.IsMovementRight(coordinates);
            Console.ForegroundColor = isValidPosition ? ConsoleColor.Green : ConsoleColor.Red;

            // Вывод информации о взаимодействии фигур
            if (isValidPosition)
            {
                if (coordinates.FirstPiece == "король")
                {
                    Console.WriteLine($"Фигура {coordinates.FirstPiece} на поле {coordinates.TargetX}{coordinates.TargetY} угрожает фигуре {coordinates.SecondPiece}");
                }
                else
                {
                    Console.WriteLine($"Фигура {coordinates.FirstPiece} на поле {coordinates.TargetX} {coordinates.TargetY} не угрожает фигуре {coordinates.SecondPiece}");
                }
            }
            else
            {
                Console.WriteLine($"Фигура {coordinates.FirstPiece} на поле {coordinates.TargetX} {coordinates.TargetY} угрожает фигуре {coordinates.SecondPiece}");
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
