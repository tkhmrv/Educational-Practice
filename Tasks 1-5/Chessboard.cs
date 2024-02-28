using System;

namespace Chess
{
    internal class Chessboard
    {
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
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    if ((char)(j + 96) == coordinates.FigureX && i == (int)Char.GetNumericValue(coordinates.FigureY))
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Цвет первой фигуры
                        Console.Write("F ");
                    }
                    else if ((char)(j + 96) == coordinates.TargetX && i == (int)Char.GetNumericValue(coordinates.TargetY))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Цвет второй фигуры
                        Console.Write("T ");
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

    }
}

