using MarsRoverKata;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class RoverShould
    {
        private const int StartingX = 1;
        private const int StartingY = 2;
        private Rover _rover;

        [TestCase('N', "R", "0 0 E")]
        [TestCase('S', "R", "0 0 W")]
        [TestCase('E', "R", "0 0 S")]
        [TestCase('W', "R", "0 0 N")]
        [TestCase('N', "RRR", "0 0 W")]
        public void RotateRightCorrectly(Orientation startingOrientation, string command, string expectedOutput)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(0, 0), startingOrientation, positionCalculator);

            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }

        [TestCase('N', "L", "0 0 W")]
        [TestCase('S', "L", "0 0 E")]
        [TestCase('E', "L", "0 0 N")]
        [TestCase('W', "L", "0 0 S")]
        [TestCase('N', "LLL", "0 0 E")]
        public void RotateLeftCorrectly(Orientation startingOrientation, string command, string expectedOutput)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(0, 0), startingOrientation, positionCalculator);

            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }

        [TestCase('N', 1, 3, 1, 5)]
        [TestCase('N', 1, 5, 3, 5)]
        [TestCase('N', 1, 5, 8, 5)]
        [TestCase('N', 1, 5, 13, 5)]
        [TestCase('N', 1, 3, 1, 3)]
        [TestCase('N', 1, 7, 5, 8)]
        [TestCase('N', 1, 7, 13, 8)]
        public void MoveNorthCorrectly(Orientation startingOrientation, int landingX, int landingY, int numberOfMoves, int gridHeight)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, positionCalculator);

            var landingPosition = new Position(StartingX, StartingY);
            landingPosition = CalculateLandingPosition(startingOrientation, numberOfMoves, gridHeight, landingPosition);

            Assert.AreEqual(landingX, landingPosition.X);
            Assert.AreEqual(landingY, landingPosition.Y);
        }

        [TestCase('E', 2, 2, 1, 5)]
        [TestCase('E', 4, 2, 3, 5)]
        [TestCase('E', 2, 2, 6, 5)]
        [TestCase('E', 4, 2, 8, 5)]
        [TestCase('E', 10, 2, 9, 10)]
        public void MoveNEastCorrectly(Orientation startingOrientation, int landingX, int landingY, int numberOfMoves, int gridWidth)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, positionCalculator);

            var landingPosition = CalculateLandingPosition(startingOrientation, numberOfMoves, gridWidth, new Position(StartingX, StartingY));

            Assert.AreEqual(landingX, landingPosition.X);
            Assert.AreEqual(landingY, landingPosition.Y);
        }

        [TestCase('W', 5, 2, 1, 5)]
        [TestCase('W', 3, 2, 3, 5)]
        [TestCase('W', 3, 2, 8, 5)]
        [TestCase('W', 5, 2, 6, 10)]
        public void MoveWestCorrectly(Orientation startingOrientation, int landingX, int landingY, int numberOfMoves, int gridWidth)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, positionCalculator);

            var landingPosition = CalculateLandingPosition(startingOrientation, numberOfMoves, gridWidth, new Position(StartingX, StartingY));

            Assert.AreEqual(landingX, landingPosition.X);
            Assert.AreEqual(landingY, landingPosition.Y);
        }

        [TestCase('S', 1, 1, 1, 5)]
        [TestCase('S', 1, 5, 2, 5)]
        [TestCase('S', 1, 4, 8, 5)]
        [TestCase('S', 1, 7, 7, 12)]
        public void MoveSouthCorrectly(Orientation startingOrientation, int landingX, int landingY, int numberOfMoves, int gridWidth)
        {
            var positionCalculator = new PositionCalculator();
            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, positionCalculator);

            var landingPosition = CalculateLandingPosition(startingOrientation, numberOfMoves, gridWidth, new Position(StartingX, StartingY));

            Assert.AreEqual(landingX, landingPosition.X);
            Assert.AreEqual(landingY, landingPosition.Y);
        }

        private Position CalculateLandingPosition(Orientation startingOrientation, int numberOfMoves, int gridDimension, Position position)
        {
            for (var i = 0; i < numberOfMoves; i++)
            {
                position = _rover.Move(new Position(position.X, position.Y), startingOrientation, gridDimension);
            }

            return position;
        }
    }
}