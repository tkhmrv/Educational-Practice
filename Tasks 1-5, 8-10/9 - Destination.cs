using System;

namespace Chess
{
    internal class Destination
    {
        // ПРОБЛЕМА: первая фигура может проходить сквозь вторую

        internal static void Check(Coordinates coordinates)
        {

            bool WhitePieceCanReachDot = WhitePiece(coordinates);
            bool BlackPieceCanBeatDot = BlackPiece(coordinates);


            if (WhitePieceCanReachDot && !BlackPieceCanBeatDot)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Белая фигура {coordinates.FirstPiece} сможет дойти до точки {coordinates.MoveX}{coordinates.MoveY}, не попав при этом под удар черной фигуры\n");
            }
            else if (WhitePieceCanReachDot && BlackPieceCanBeatDot)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Белая фигура {coordinates.FirstPiece} сможет дойти до точки {coordinates.MoveX} {coordinates.MoveY}, но будет побита черной фигурой\n");
            }
            else if (!WhitePieceCanReachDot && BlackPieceCanBeatDot)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Белая фигура {coordinates.FirstPiece} не сможет дойти до точки {coordinates.MoveX} {coordinates.MoveY}, но может быть побита черной фигурой\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Белая фигура {coordinates.FirstPiece} не сможет дойти до точки {coordinates.MoveX}   {coordinates.MoveY}, и не будет побита черной фигурой\n");
            }

            Console.ResetColor();
        }

        // Метод для проверки возможности белой фигуры дойти до точки
        internal static bool WhitePiece(Coordinates coordinates)
        {
            bool WhitePieceCanReachDot;
            int diffX = Math.Abs(coordinates.MoveX - coordinates.PieceX);
            int diffY = Math.Abs(coordinates.MoveY - coordinates.PieceY);

            // Проверяем, что белая фигура в списке допустимых фигур, а также она может ходить до точки
            switch (coordinates.FirstPiece.Trim().ToLower())
            {
                case "ладья":
                    // Ладья может ходить по горизонтали и вертикали
                    WhitePieceCanReachDot = coordinates.PieceX == coordinates.MoveX || coordinates.PieceY == coordinates.MoveY;
                    break;
                case "конь":
                    // Конь ходит буквой "Г"
                    WhitePieceCanReachDot = (diffX == 1 && diffY == 2) || (diffX == 2 && diffY == 1);
                    break;
                case "слон":
                    // Слон ходит по диагонали
                    WhitePieceCanReachDot = diffX == diffY;
                    break;
                case "ферзь":
                    // Ферзь может ходить по диагоналям и по прямым линиям
                    WhitePieceCanReachDot = coordinates.PieceX == coordinates.MoveX || coordinates.PieceY == coordinates.MoveY || diffX == diffY;
                    break;
                case "король":
                    // Король ходит на одну клетку в любом направлении
                    WhitePieceCanReachDot = diffX <= 1 && diffY <= 1;
                    break;
                default:
                    // Если введена недопустимая фигура, считаем, что она не может дойти до указанной точки
                    Console.WriteLine("Введена недопустимая белая фигура");
                    WhitePieceCanReachDot = false;
                    break;
            }
            return WhitePieceCanReachDot;
        }

        // Метод для проверки возможности черной фигуры побить белую фигуру на позиции точки
        internal static bool BlackPiece(Coordinates coordinates)
        {
            bool BlackPieceCanBeatDot;
            int diffX = Math.Abs(coordinates.MoveX - coordinates.TargetX);
            int diffY = Math.Abs(coordinates.MoveY - coordinates.TargetY);

            // Проверяем, что черная фигура может побить белую фигуры на позиции точки
            switch (coordinates.SecondPiece.Trim().ToLower())
            {
                case "ладья":
                    // Ладья может ходить по горизонтали и вертикали
                    BlackPieceCanBeatDot = coordinates.TargetX == coordinates.MoveX || coordinates.TargetY == coordinates.MoveY;
                    break;
                case "конь":
                    // Конь ходит буквой "Г"
                    BlackPieceCanBeatDot = (diffX == 1 && diffY == 2) || (diffX == 2 && diffY == 1);
                    break;
                case "слон":
                    // Слон ходит по диагонали
                    BlackPieceCanBeatDot = diffX == diffY;
                    break;
                case "ферзь":
                    // Ферзь может ходить по диагоналям и по прямым линиям
                    BlackPieceCanBeatDot = coordinates.TargetX == coordinates.MoveX || coordinates.TargetY == coordinates.MoveY || diffX == diffY;
                    break;
                case "король":
                    // Король ходит на одну клетку в любом направлении
                    BlackPieceCanBeatDot = diffX <= 1 && diffY <= 1;
                    break;
                default:
                    // Если введена недопустимая фигура, считаем, что она не может дойти до указанной точки
                    Console.WriteLine("Введена недопустимая черная фигура");
                    BlackPieceCanBeatDot = false;
                    break;
            }
            return BlackPieceCanBeatDot;
        }
    }
}
