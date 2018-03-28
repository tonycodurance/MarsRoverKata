using System.Collections.Generic;
using System.Linq;
using static MarsRoverKata.Orientation;

namespace MarsRoverKata
{
    public class PositionCalculator
    {
        public Orientation CalculateOnRight(Orientation orientation)
        {
            var rightRotations = new List<Orientation>{North, East, South, West};

            return Calculate(rightRotations, orientation);
        }

        public Orientation CalculateOnLeft(Orientation orientation)
        {
            var leftRotations = new List<Orientation>{North, West, South, East};

            return Calculate(leftRotations, orientation);            
        }

        private Orientation Calculate(List<Orientation> rotations, Orientation orientation)
        {
            var newOrientationIndex = 0;
            var currentOrientationIndex = rotations.FindIndex(
                or => or == orientation
            );

            var currentOrientationAtTheEndOfList =
                currentOrientationIndex == rotations.Count - 1;

            if (!currentOrientationAtTheEndOfList)
            {
                newOrientationIndex = currentOrientationIndex + 1;
            }

            return rotations.ElementAt(newOrientationIndex);
        }
    }
}