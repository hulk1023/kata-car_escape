using System;

namespace CarParking
{
    public class EscapeRoute
    {
        public string[] FindRoute(int[][] carParking)
        {
            int[] _carPosition = new int[2] {carParking.Length - 1, -1};
            _carPosition = FindCarPosition(carParking, _carPosition);

            int lotsToEscape = carParking[_carPosition[0]].Length - _carPosition[1] - 1;

            return new string[]{$"R{lotsToEscape.ToString()}"};


        }

        int[] FindCarPosition(int[][] carParking, int[] _carPosition)
        {
            int[] _carPositionRefreshed = (int[])_carPosition.Clone();

            if (_carPositionRefreshed[1] != -1)
            {
                return _carPositionRefreshed;
            }

            int _lotPosition = 0;
            while (_lotPosition < carParking[_carPositionRefreshed[0]].Length)
            {
                if (carParking[_carPositionRefreshed[0]][_lotPosition] == 2)
                {
                    _carPositionRefreshed[1] = _lotPosition;
                    break;
                }

                _lotPosition++;
            }

            if (_carPositionRefreshed[1] == -1)
            {
                _carPositionRefreshed[0]--;
            }

            return FindCarPosition(carParking, _carPositionRefreshed);
        }
    }
}
