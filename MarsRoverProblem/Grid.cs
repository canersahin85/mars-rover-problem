namespace MarsRoverProblem
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The grid class that Rover can move
    /// </summary>
    public class Grid
    {
        private Coordinates _maxCoordinates;
        private readonly List<Rover> _allRoversOnGrid;

        
        public Grid(Coordinates _maxCor)
        {
            //Maximum coordinates
            _maxCoordinates = _maxCor;
            _allRoversOnGrid = new List<Rover>();
        }

        //Method for adding Rovers to the list for movement
        public void AddToRoverCollection(Rover _roverObj)
        {
            _allRoversOnGrid.Add(_roverObj);
        }

        //The method of moving rovers on the grid
        public void MoveAllRoversOnGrid()
        {
            foreach (Rover tempRov in _allRoversOnGrid)
            {
                tempRov.ProcessDirectiveArray();
                DoIntegrityCheck(tempRov);
            }
        }

        //Checking for Rover to stay in grid
        private void DoIntegrityCheck(Rover _tempRov)
        {
            if ((_tempRov.X > _maxCoordinates.X) || (_tempRov.Y > _maxCoordinates.Y))
            {
                throw new Exception("Rover stepped off the Grid.");
            }
        }
    }
}