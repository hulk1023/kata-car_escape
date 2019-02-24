using System;
using System.Collections.Generic;

namespace CarParking
{
    public class EscapeRoute
    {
        public string[] FindRoute(int[][] carParking)
        {
            List<string> escapeSteps = new List<string>();

            int[] _carInitPosition = new int[2] {carParking.Length - 1, -1};
            _carInitPosition = FindCarPosition(carParking, _carInitPosition);

            int[] _carNowPosition = new int[2]{-1, -1};

            if (_carInitPosition[0] < carParking.Length - 1)
            {
                int _stairCasePosition = 0;
                while (_stairCasePosition < carParking[_carInitPosition[0]].Length)
                {
                    if (carParking[_carInitPosition[0]][_stairCasePosition] == 1)
                    {
                        break;
                    }

                    _stairCasePosition++;
                }

                int lotsToStaircase = _stairCasePosition - _carInitPosition[1];
                string direction = _stairCasePosition > 0 ? "R" : "L";
                escapeSteps.Add($"{direction}{Math.Abs(lotsToStaircase)}");

                _carNowPosition[0] = _carInitPosition[0] + 1;
                _carNowPosition[1] = lotsToStaircase;
                escapeSteps.Add("D1");
            }
            else
            {
                _carNowPosition = (int[]) _carInitPosition.Clone();
            }

            int lotsToEscape = carParking[_carNowPosition[0]].Length - _carNowPosition[1] - 1;

            if (lotsToEscape != 0)
            {
                escapeSteps.Add($"R{lotsToEscape.ToString()}");
            }

            return escapeSteps.ToArray();


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
