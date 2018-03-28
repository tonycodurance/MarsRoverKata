using System;

namespace MarsRoverKata
{
    public class Rover
    {
        private Position _position;
        private readonly Orientation _orientation;
        private readonly OrientationCalculator _orientationCalculator;
        private readonly PositionCalculator _positionCalculator;

        public Rover(Position position, Orientation orientation, OrientationCalculator orientationCalculator, PositionCalculator positionCalculator)
        {
            _position = position;
            _orientation = orientation;
            _orientationCalculator = orientationCalculator;
            _positionCalculator = positionCalculator;
        }

        public string ExecuteCommand(string command)
        {
            var orientation = _orientation;

            foreach (var character in command)
            {
                if (character == 'R')
                {
                    orientation = _orientationCalculator.CalculateOnRight(orientation);
                }

                if (character == 'L')
                {
                    orientation = _orientationCalculator.CalculateOnLeft(orientation);
                }

                if (character == 'M')
                {
                    _position = _positionCalculator.Calculate(_position, _orientation);
                }
            }

            return $"{_position.X} {_position.Y} {(char)orientation}";
        }
    }
}