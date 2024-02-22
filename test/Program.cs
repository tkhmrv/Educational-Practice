using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите координаты первого поля (например, a1):");
            string position1 = Console.ReadLine();
            Console.WriteLine("Введите координаты второго поля (например, b2):");
            string position2 = Console.ReadLine();

            bool isSameColor = IsSameColor(position1, position2);

            Console.WriteLine("Поля {0} и {1} являются полями одного цвета: {2}", position1, position2, isSameColor ? "Да" : "Нет");

            DrawChessboard();

            ExitProgram();
        }

        static bool IsSameColor(string position1, string position2)
        {
            int x1 = position1[0] - 'a';
            int y1 = position1[1] - '1';
            int x2 = position2[0] - 'a';
            int y2 = position2[1] - '1';

            return (x1 + y1) % 2 == (x2 + y2) % 2;
        }

        static void DrawChessboard()
        {
            char[,] board = new char[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i, j] = (i + j) % 2 == 0 ? '█' : ' ';
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        internal static void ExitProgram()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
