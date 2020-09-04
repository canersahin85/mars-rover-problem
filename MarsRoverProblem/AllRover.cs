namespace MarsRoverProblem
{
    using System.Collections.Generic;

    /// <summary>
    /// Tüm Roverların koordinatlarını tutan struct
    /// </summary>
    public struct AllRoverCoordinates
    {
        private List<string> _roverCoordinatesList;

        public List<string> RoverCoordinatesList
        {
            get
            {
                if (this._roverCoordinatesList == null)
                {
                    this._roverCoordinatesList = new List<string>();
                }

                return this._roverCoordinatesList;
            }
        }

        public void AddCoordinates(string roverCoordinates)
        {
            RoverCoordinatesList.Add(roverCoordinates);
        }
    }
}
