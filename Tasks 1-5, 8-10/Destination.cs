
// ПРОБЛЕМА: первая фигура может проходить сквозь вторую

using System;

namespace Chess
{
    internal class Destination
    {
        internal static void Check(Coordinates coordinates)
        {

            bool WhitePieceCanReach = WhitePiece(coordinates);
            bool BlackPieceCanBeatDot = BlackPiece(coordinates);


            if (WhitePieceCanReach && !BlackPieceCanBeatDot)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Белая фигура {coordinates.FirstPiece} сможет дойти до точки {coordinates.MoveX}{coordinates.MoveY}, не попав при этом под удар черной фигуры\n");
            }
            else if (WhitePieceCanReach && BlackPieceCanBeatDot)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Белая фигура {coordinates.FirstPiece} сможет дойти до точки {coordinates.MoveX} {coordinates.MoveY}, но будет побита черной фигурой\n");
            }
            else if (!WhitePieceCanReach && BlackPieceCanBeatDot)
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
        internal static bool WhitePiece(Coordinates coordinates)
        {
            bool WhitePieceCanReachDestination;
            int diffX = Math.Abs(coordinates.MoveX - coordinates.PieceX);
            int diffY = Math.Abs(coordinates.MoveY - coordinates.PieceY);

            // Проверяем, что белая фигура в списке допустимых фигур, а также она может ходить до точки
            switch (coordinates.FirstPiece.Trim().ToLower())
            {
                case "ладья":
                    // Ладья может ходить по горизонтали и вертикали
                    WhitePieceCanReachDestination = coordinates.PieceX == coordinates.MoveX || coordinates.PieceY == coordinates.MoveY;
                    break;
                case "конь":
                    // Конь ходит буквой "Г"
                    WhitePieceCanReachDestination = (diffX == 1 && diffY == 2) || (diffX == 2 && diffY == 1);
                    break;
                case "слон":
                    // Слон ходит по диагонали
                    WhitePieceCanReachDestination = diffX == diffY;
                    break;
                case "ферзь":
                    // Ферзь может ходить по диагоналям и по прямым линиям
                    WhitePieceCanReachDestination = coordinates.PieceX == coordinates.MoveX || coordinates.PieceY == coordinates.MoveY || diffX == diffY;
                    break;
                case "король":
                    // Король ходит на одну клетку в любом направлении
                    WhitePieceCanReachDestination = diffX <= 1 && diffY <= 1;
                    break;
                default:
                    // Если введена недопустимая фигура, считаем, что она не может дойти до указанной точки
                    Console.WriteLine("Введена недопустимая белая фигура");
                    WhitePieceCanReachDestination = false;
                    break;
            }
            return WhitePieceCanReachDestination;
        }

        internal static bool BlackPiece(Coordinates coordinates)
        {
            bool BlackPieceCanReachDestination;
            int diffX = Math.Abs(coordinates.MoveX - coordinates.TargetX);
            int diffY = Math.Abs(coordinates.MoveY - coordinates.TargetY);

            // Проверяем, что черная фигура может побить белую фигуры на позиции точки
            switch (coordinates.SecondPiece.Trim().ToLower())
            {
                case "ладья":
                    // Ладья может ходить по горизонтали и вертикали
                    BlackPieceCanReachDestination = coordinates.TargetX == coordinates.MoveX || coordinates.TargetY == coordinates.MoveY;
                    break;
                case "конь":
                    // Конь ходит буквой "Г"
                    BlackPieceCanReachDestination = (diffX == 1 && diffY == 2) || (diffX == 2 && diffY == 1);
                    break;
                case "слон":
                    // Слон ходит по диагонали
                    BlackPieceCanReachDestination = diffX == diffY;
                    break;
                case "ферзь":
                    // Ферзь может ходить по диагоналям и по прямым линиям
                    BlackPieceCanReachDestination = coordinates.TargetX == coordinates.MoveX || coordinates.TargetY == coordinates.MoveY || diffX == diffY;
                    break;
                case "король":
                    // Король ходит на одну клетку в любом направлении
                    BlackPieceCanReachDestination = diffX <= 1 && diffY <= 1;
                    break;
                default:
                    // Если введена недопустимая фигура, считаем, что она не может дойти до указанной точки
                    Console.WriteLine("Введена недопустимая черная фигура");
                    BlackPieceCanReachDestination = false;
                    break;
            }
            return BlackPieceCanReachDestination;
        }
    }
}
