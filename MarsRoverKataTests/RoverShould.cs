using System.Collections;
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
            var orientationCalculator = new OrientationCalculator();
            var positionCalculator = new PositionCalculator(new Grid(5, 5));
            _rover = new Rover(new Position(0, 0), startingOrientation, orientationCalculator, positionCalculator);

            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }

        [TestCase('N', "L", "0 0 W")]
        [TestCase('S', "L", "0 0 E")]
        [TestCase('E', "L", "0 0 N")]
        [TestCase('W', "L", "0 0 S")]
        [TestCase('N', "LLL", "0 0 E")]
        public void RotateLeftCorrectly(Orientation startingOrientation, string command, string expectedOutput)
        {
            var orientationCalculator = new OrientationCalculator();
            var positionCalculator = new PositionCalculator(new Grid(5, 5));
            _rover = new Rover(new Position(0, 0), startingOrientation, orientationCalculator, positionCalculator);

            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }

        private static IEnumerable PositionTestCases
        {
            get
            {
                yield return new TestCaseData('N', "M", new Grid(5, 5), "1 3 N");
                yield return new TestCaseData('N', "MMMM", new Grid(5, 5), "1 1 N");
                yield return new TestCaseData('E', "M", new Grid(5, 5), "2 2 E");
                yield return new TestCaseData('E', "MMMMMMMM", new Grid(5, 5), "4 2 E");
                yield return new TestCaseData('W', "MMM", new Grid(5, 5), "3 2 W");
                yield return new TestCaseData('W', "MMMMMM", new Grid(5, 5), "5 2 W");
                yield return new TestCaseData('S', "M", new Grid(5, 5), "1 1 S");
                yield return new TestCaseData('S', "MMMMMMMMMMMMM", new Grid(5, 5), "1 4 S");
            }
        }

        [Test, TestCaseSource(nameof(PositionTestCases))]
        public void MoveCorrectly(Orientation startingOrientation, string command, Grid grid, string expectedOutput)
        {
            var orientationCalculator = new OrientationCalculator();
            var positionCalculator = new PositionCalculator(grid);
            _rover = new Rover(new Position(StartingX, StartingY), startingOrientation, orientationCalculator, positionCalculator);

            Assert.AreEqual(_rover.ExecuteCommand(command), expectedOutput);
        }
    }
}