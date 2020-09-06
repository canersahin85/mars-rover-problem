namespace MarsRoverProblem
{
    using Enums;

    /// <summary>
    /// The struct that holds the coordinates of Rover
    /// </summary>
    public struct Coordinates
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinates(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        public void UpdateCoordinates(DirectionsEnum directionObj)
        {
            switch (directionObj)
            {
                case DirectionsEnum.N:
                    Y++;
                    break;
                case DirectionsEnum.S:
                    Y--;
                    break;
                case DirectionsEnum.E:
                    X++;
                    break;
                case DirectionsEnum.W:
                    X--;
                    break;
            }
        }
    }
}
