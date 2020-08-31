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
    }
}