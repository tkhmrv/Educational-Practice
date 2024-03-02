using System;

namespace Chess
{
    internal class Chessboard
    {
        // Tasks 1-5, 8, 9
        internal static void DrawChessboard(Coordinates coordinates)
        {
            Console.WriteLine("   a b c d e f g h");
            for (int i = 8; i >= 1; i--)
            {
                Console.Write($" {i} ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Цвет шахматки доски
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    if ((char)(j + 96) == coordinates.PieceX && i == (int)Char.GetNumericValue(coordinates.PieceY))
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Цвет первой фигуры
                        Console.Write("Ф ");
                    }
                    else if ((char)(j + 96) == coordinates.TargetX && i == (int)Char.GetNumericValue(coordinates.TargetY))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Цвет второй фигуры
                        Console.Write("Ц ");
                    }
                    else if ((char)(j + 96) == coordinates.MoveX && i == (int)Char.GetNumericValue(coordinates.MoveY))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Цвет точки
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Task 10
        internal static void DrawChessboardRandom(Coordinates coordinates)
        {
            Console.WriteLine("   a b c d e f g h");

            for (int i = 8; i >= 1; i--)
            {
                Console.Write($" {i} ");
                for (int j = 1; j <= 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray; // Цвет шахматки доски
                    else
                        Console.ResetColor();

                    if (i == coordinates.PieceY - '0' && j == coordinates.PieceX - 'a' + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Цвет первой фигуры
                        Console.Write("1" + coordinates.FirstPiece.Substring(0, 1).ToUpper());
                    }
                    else if (i == coordinates.TargetY - '0' && j == coordinates.TargetX - 'a' + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Цвет второй фигуры
                        Console.Write("2" + coordinates.SecondPiece.Substring(0, 1).ToUpper());
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}