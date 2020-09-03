namespace Rover
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Rover'ın gezebileceği grid class ı
    /// </summary>
    public class Grid
    {
        private Coordinates _maxCoordinates;
        private AllRoverCoordinates _allRoverCoordinates;
        private readonly List<MarsRover> _allRoversOnGrid;

        
        public Grid(Coordinates _maxCor)
        {
            //Maksimum koordinatlar set ediliyor.
            _maxCoordinates = _maxCor;
            _allRoversOnGrid = new List<MarsRover>();
        }

        //Roverların hareket için listeye eklenmesini sağlayan method
        public void AddToRoverCollection(MarsRover _roverObj)
        {
            _allRoversOnGrid.Add(_roverObj);
        }

        //Grid içinde roverların hareket işlemlerinin yapıldığı method
        public void MoveAllRoversOnGrid()
        {
            foreach (MarsRover tempRov in _allRoversOnGrid)
            {
                tempRov.ProcessDirectiveArray();
                DoIntegrityCheck(tempRov);
                CanRoverMoveCheck(tempRov);
            }
        }

        //Rover ın grid içinde kalmasını kontrol ediyoruz.
        private void DoIntegrityCheck(MarsRover _tempRov)
        {
            if ((_tempRov.X > _maxCoordinates.X) || (_tempRov.Y > _maxCoordinates.Y))
            {
                throw new Exception("Rover Grid dışına çıktı. Tekrar dene.");
            }
        }

        //Rover ın gideceği noktada başka rover olup olmadığını kontrol ediyoruz.
        private void CanRoverMoveCheck(MarsRover _tempRov)
        {
            var currentRoverCoordinates = $"{_tempRov.X} {_tempRov.Y} {_tempRov.RoverDirection}";

            if (_allRoverCoordinates.RoverCoordinatesList != null)
            {
                foreach (var roverCoordinates in _allRoverCoordinates.RoverCoordinatesList)
                {
                    if (roverCoordinates == currentRoverCoordinates)
                    {
                        throw new Exception("Aynı noktada başka bir Rover var.");
                    }
                }
            }

            _allRoverCoordinates.AddCoordinates(currentRoverCoordinates);
        }
    }
}