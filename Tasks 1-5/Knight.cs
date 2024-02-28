using System;

namespace Chess
{
    internal class Knight
    {
        internal static void KnightLogic(Coordinates coordinates)
        {
            if (CanKnightAttack(coordinates.PieceX, coordinates.PieceY, coordinates.TargetX, coordinates.TargetY))
            {
                Console.WriteLine("Конь сможет побить фигуру\n");
            }
            else
            {
                Console.WriteLine("Конь не сможет побить фигуру\n");
            }
        }
        static bool CanKnightAttack(char knightX, char knightY, char targetX, char targetY)
        {
            int dx = Math.Abs(knightX - targetX);
            int dy = Math.Abs(knightY - targetY);
            return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);
        }
    }
}
