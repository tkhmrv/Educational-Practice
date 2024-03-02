using System;

namespace Chess
{
    internal class Queen
    {
        internal static void QueenLogic(Coordinates coordinates)
        {
            if (IsQueenAbleToHitTarget(coordinates.PieceX, coordinates.PieceY, coordinates.TargetX, coordinates.TargetY))
            {
                Console.WriteLine("Ферзь сможет побить фигуру\n");
            }
            else
            {
                Console.WriteLine("Ферзь не сможет побить фигуру\n");
            }
        }

        static bool IsQueenAbleToHitTarget(char queenX, char queenY, char tagretX, char targetY)
        {
            return queenX == tagretX || queenY == targetY || Math.Abs(queenX - tagretX) == Math.Abs(queenY - targetY);
        }
    }
}
