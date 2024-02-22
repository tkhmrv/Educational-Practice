using System;

namespace Tasks_1_5
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Выберите вариант использования (1 - ладья, 2 - слон, 3 - ферзь, 4 - король, 5 - конь, 6 - цвет поля, 0 - выход из программы): ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
                {
                    Console.WriteLine("Пожалуйста, введите число от 0 до 5:");
                }

                switch (choice)
                {
                    case 0:
                        ExitProgram();
                        break;
                    case 1:
                        Coordinates RookCoordinates = Coordinates.CoordinatesLogic("ладья");
                        Rook.RookLogic(RookCoordinates);
                        Chessboard.DrawChessboard(RookCoordinates);
                        break;
                    case 2:
                        Coordinates BishopCoordinates = Coordinates.CoordinatesLogic("слон");
                        Bishop.BishopLogic(BishopCoordinates);
                        Chessboard.DrawChessboard(BishopCoordinates);
                        break;
                    case 3:
                        Coordinates QueenCoordinates = Coordinates.CoordinatesLogic("ферзь");
                        Queen.QueenLogic(QueenCoordinates);
                        Chessboard.DrawChessboard(QueenCoordinates);
                        break;
                    case 4:
                        Coordinates KingCoordinates = Coordinates.CoordinatesLogic("король");
                        King.KingLogic(KingCoordinates);
                        Chessboard.DrawChessboard(KingCoordinates);
                        break;
                    case 5:
                        Coordinates KnightCoordinates = Coordinates.CoordinatesLogic("конь");
                        Knight.KnightLogic(KnightCoordinates);
                        Chessboard.DrawChessboard(KnightCoordinates);
                        break;
                    case 6:
                        Coordinates FieldCoordinates = Coordinates.CoordinatesLogic("поля");
                        Fields.FieldsLogic(FieldCoordinates);
                        Chessboard.DrawChessboard(FieldCoordinates);
                        break;
                }
            }
        }

        internal static void ExitProgram()
        {
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
