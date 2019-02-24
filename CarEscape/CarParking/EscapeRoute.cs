using System;

namespace CarParking
{
    public class EscapeRoute
    {
        public string[] FindRoute(int[][] carParking)
        {
            int _lv = 0;
            int _carPosition = -1;

            _lv = carParking.Length - 1;

            int _lotPosition = 0;
            int[] _lotsOnTheLevel = carParking[_lv];
            while (_lotPosition < _lotsOnTheLevel.Length)
            {
                if (_lotsOnTheLevel[_lotPosition] == 2)
                {
                    _carPosition = _lotPosition;
                    break;
                }
            }

            int lotsToEscape = _lotsOnTheLevel.Length - _carPosition - 1;

            return new string[]{$"R{lotsToEscape.ToString()}"};
        }
    }
}
