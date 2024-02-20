using System;

namespace Tasks_1_5
{
    internal class King
    {
        internal static void KingLogic(Coordinates coordinates)
        {
            if (CanKingAttack(coordinates.FigureX, coordinates.FigureY, coordinates.TargetX, coordinates.TargetY))
            {
                Console.WriteLine("Король сможет побить фигуру\n");
            }
            else
            {
                Console.WriteLine("Король не сможет побить фигуру\n");
            }
        }
        static bool CanKingAttack(char kingX, char kingY, char targetX, char targetY)
        {
            return Math.Abs(kingX - targetX) <= 1 && Math.Abs(kingY - targetY) <= 1;
        }
    }
}
