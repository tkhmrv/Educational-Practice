using System;

namespace Chess
{
    internal class Randomizer
    {
        internal static void RandomLogic(Coordinates coordinates)
        {
            Console.WriteLine("\nПервая фигура - " + coordinates.FirstPiece + ", Вторая фигура - " + coordinates.SecondPiece);

            bool isValidPosition = Coordinates.IsMovementRight(coordinates);
            Console.ForegroundColor = isValidPosition ? ConsoleColor.Green : ConsoleColor.Red;

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
