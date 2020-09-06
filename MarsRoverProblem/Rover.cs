namespace MarsRoverProblem
{
    using Enums;
    using System;

    public class Rover
    {
        private Coordinates _roverCoordinates;
        private readonly string _directiveArray;
        private AllRoverCoordinates _allRoverCoordinates;

        public int X => _roverCoordinates.X;
        public int Y => _roverCoordinates.Y;
        public DirectionsEnum RoverDirection { get; private set; }

        public Rover(int xCoordinate, int yCoordinate, char startDirection, string directiveArray)
        {
            _roverCoordinates = new Coordinates(xCoordinate, yCoordinate);
            RoverDirection = GetDirection(startDirection);
            _directiveArray = directiveArray;
        }

        private DirectionsEnum GetDirection(char startDirection)
        {
            return startDirection switch
            {
                'N' => DirectionsEnum.N,
                'S' => DirectionsEnum.S,
                'E' => DirectionsEnum.E,
                'W' => DirectionsEnum.W,
                _ => throw new Exception("Accepted values ==> N,S,E,W "),
            };
        }

        public void ProcessDirectiveArray()
        {
            foreach (var instruction in _directiveArray)
            {
                Process(instruction);
                if (_allRoverCoordinates.RoverCoordinatesList.Count > 0)
                {
                    //I check if there is another rover at the point where Rover is going.
                    CanRoverMoveCheck();
                }
            }
            //Rover's last coordinate add to the list.
            var currentRoverCoordinates = $"{_roverCoordinates.X} {_roverCoordinates.Y} {RoverDirection}";
            _allRoverCoordinates.AddCoordinates(currentRoverCoordinates);
        }

        private void Process(char directive)
        {
            if ((directive == 'L') || (directive == 'R'))
                ProcessDirection(directive);
            else if (directive == 'M')
                ProcessMove();
            else
                throw new Exception("Invalid process. You can use only L,R and M");
        }

        private void ProcessMove()
        {
            _roverCoordinates.UpdateCoordinates(RoverDirection);
        }

        private void ProcessDirection(char directive)
        {
            var _roverDirectionInt = Convert.ToInt32(RoverDirection);

            if (directive == 'L')
            {
                if (_roverDirectionInt == 0)
                    _roverDirectionInt = 4;
                RoverDirection = (DirectionsEnum)(_roverDirectionInt - 1);
            }
            else
            {
                if (_roverDirectionInt == 3)
                    _roverDirectionInt = -1;
                RoverDirection = (DirectionsEnum)(_roverDirectionInt + 1);
            }
        }

        private void CanRoverMoveCheck()
        {
            var currentRoverCoordinates = $"{_roverCoordinates.X} {_roverCoordinates.Y} {RoverDirection}";

            if (_allRoverCoordinates.RoverCoordinatesList != null)
            {
                foreach (var roverCoordinates in _allRoverCoordinates.RoverCoordinatesList)
                {
                    if (roverCoordinates == currentRoverCoordinates)
                    {
                        throw new Exception("There's another Rover in the same place.");
                    }
                }
            }
        }
    }
}
