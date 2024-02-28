using System;

namespace Chess
{
    internal class Rook
    {
        internal static void RookLogic(Coordinates coordinates)
        {
            if (coordinates.PieceX == coordinates.TargetX || coordinates.PieceY == coordinates.TargetY)
            {
                Console.WriteLine("Ладья сможет побить фигуру\n");
            }
            else
            {
                Console.WriteLine("Ладья не сможет побить фигуру\n");
            }
        }
    }
}
