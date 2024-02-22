using System;

namespace Chess
{
    internal class Chessboard
    {
        internal static void DrawChessboard(Coordinates coordinates)
        {
            char[,] board = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = (i + j) % 2 == 0 ? '█' : ' ';
                }
            }

            board[8 - (coordinates.FigureY - '0'), coordinates.FigureX - 'a'] = 'F';
            board[8 - (coordinates.TargetY - '0'), coordinates.TargetX - 'a'] = 'T';

            for (int i = 0; i < 8; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h\n");
        }
    }
}
