using System;

namespace Tasks_1_5
{
    internal class Bishop
    {
        internal static void BishopLogic(Coordinates coordinates)
        {
            if (Math.Abs(coordinates.FigureX - coordinates.TargetX) == Math.Abs(coordinates.FigureY - coordinates.TargetY))
            {
                Console.WriteLine("Слон сможет побить фигуру\n");
            }
            else
            {
                Console.WriteLine("Слон не сможет побить фигуру\n");
            }
        }
    }
}
