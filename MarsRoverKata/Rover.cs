using static MarsRoverKata.Orientation;

namespace MarsRoverKata
{
    public class Rover
    {
        private const int MaxHeight = 5;
        private readonly Position _position;
        private readonly Orientation _orientation;
        private readonly PositionCalculator _positionCalculator;

        public Rover(Position position, Orientation orientation, PositionCalculator positionCalculator)
        {
            _position = position;
            _orientation = orientation;
            _positionCalculator = positionCalculator;
        }

        public string ExecuteCommand(string command)
        {
            var orientation = _orientation;

            foreach (var character in command)
            {
                if (character == 'R')
                {
                    orientation = _positionCalculator.CalculateOnRight(orientation);
                }

                if (character == 'L')
                {
                    orientation = _positionCalculator.CalculateOnLeft(orientation);
                }
            }

            return $"{_position.X} {_position.Y} {(char)orientation}";
        }

        public Position Move(Position position, Orientation orientation, int gridDimension)
        {
            var newX = position.X;
            var newY = position.Y;
            if (orientation == North)
            {
                newY = position.Y % gridDimension + 1;
            }

            if (orientation == East)
            {
                newX = position.X % gridDimension + 1;
            }

            if (orientation == West)
            {
                newX = newX > 1 ? newX - 1 : gridDimension;
            }

            if (orientation == South)
            {
                newY = newY > 1 ? newY - 1 : gridDimension;
            }
            return new Position(newX, newY);
        }
    }
}