using System;

namespace Chess
{
    internal class Fields
    {
        internal static void FieldsLogic(Coordinates coordinates)
        {
            bool isSameColor = IsSameColor(coordinates);

            if (isSameColor)
            {
                Console.WriteLine("Поля одного цвета\n");
            }
            else
            {
                Console.WriteLine("Поля разного цвета\n");
            }
        }

        static bool IsSameColor(Coordinates coordinates)
        {
            int x1 = coordinates.PieceX - 'a';
            int y1 = coordinates.PieceY - '1';
            int x2 = coordinates.TargetX - 'a';
            int y2 = coordinates.TargetY - '1';

            return (x1 + y1) % 2 == (x2 + y2) % 2;
        }
    }
}
