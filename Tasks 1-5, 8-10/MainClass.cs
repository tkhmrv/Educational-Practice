using System;

namespace Chess
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Выберите номер задания (1 - Задания 1-5 и 8, 2 - Задание 9, 3 - Задание 10, 0 - выход из программы): ");
                int TaskChoice;
                while (!int.TryParse(Console.ReadLine(), out TaskChoice) || TaskChoice < 0 || TaskChoice > 3)
                {
                    Console.WriteLine("Пожалуйста, введите число от 0 до 3: ");
                }

                switch (TaskChoice)
                {
                    case 0:
                        ExitProgram();
                        break;
                    case 1:
                        {
                            Console.Write("Выберите вариант использования (1 - ладья, 2 - слон, 3 - ферзь, 4 - король, 5 - конь, 6 - цвет поля, 0 - вернуться к заданиям): ");
                            int choice;
                            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 6)
                            {
                                Console.WriteLine("Пожалуйста, введите число от 0 до 6: ");
                            }

                            switch (choice)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Coordinates RookCoordinates = Coordinates.CoordinatesBasic("ладья");
                                    Rook.RookLogic(RookCoordinates);
                                    Chessboard.DrawChessboard(RookCoordinates);
                                    break;
                                case 2:
                                    Coordinates BishopCoordinates = Coordinates.CoordinatesBasic("слон");
                                    Bishop.BishopLogic(BishopCoordinates);
                                    Chessboard.DrawChessboard(BishopCoordinates);
                                    break;
                                case 3:
                                    Coordinates QueenCoordinates = Coordinates.CoordinatesBasic("ферзь");
                                    Queen.QueenLogic(QueenCoordinates);
                                    Chessboard.DrawChessboard(QueenCoordinates);
                                    break;
                                case 4:
                                    Coordinates KingCoordinates = Coordinates.CoordinatesBasic("король");
                                    King.KingLogic(KingCoordinates);
                                    Chessboard.DrawChessboard(KingCoordinates);
                                    break;
                                case 5:
                                    Coordinates KnightCoordinates = Coordinates.CoordinatesBasic("конь");
                                    Knight.KnightLogic(KnightCoordinates);
                                    Chessboard.DrawChessboard(KnightCoordinates);
                                    break;
                                case 6:
                                    Coordinates FieldCoordinates = Coordinates.CoordinatesBasic("поля");
                                    Fields.FieldsLogic(FieldCoordinates);
                                    Chessboard.DrawChessboard(FieldCoordinates);
                                    break;
                            }
                            break;
                        }
                    case 2:
                        Coordinates DestinationReachData = Coordinates.CoordinatesAdvanced();
                        Destination.Check(DestinationReachData);
                        Chessboard.DrawChessboard(DestinationReachData);
                        break;
                    case 3:
                        Coordinates RandomCoordinates = Coordinates.CoordinatesRandom();
                        Randomizer.RandomLogic(RandomCoordinates);
                        Chessboard.DrawChessboardRandom(RandomCoordinates);
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
