namespace MarsRoverKata
{
    public class PositionCalculator
    {
        private readonly Grid _grid;

        public PositionCalculator(Grid grid)
        {
            _grid = grid;
        }

        public Position Calculate(Position position, Orientation orientation)
        {
            var newX = position.X;
            var newY = position.Y;
            
            if (orientation == Orientation.North)
            {
                newY = newY < _grid.Height ? newY + 1 : 1;
            }

            if (orientation == Orientation.East)
            {
                newX = newX < _grid.Width ? newX + 1 : 1;
            }

            if (orientation == Orientation.West)
            {
                newX = newX > 1 ? newX - 1 : _grid.Width;
            }

            if (orientation == Orientation.South)
            {
                newY = newY > 1 ? newY - 1 : _grid.Height;
            }
            return new Position(newX, newY);
        }
    }
}