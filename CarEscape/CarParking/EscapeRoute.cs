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
                var movingInfo = GoDownStair(carParking, _carInitPosition, escapeSteps);
                escapeSteps = movingInfo.Steps;
                _carNowPosition = movingInfo.NewPosition;
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

        private CarMovingInfo GoDownStair(int[][] carParking, int[] _carInitPosition, List<string> escapeSteps)
        {
            if (_carInitPosition[0] == (carParking.Length - 1))
            {
                return new CarMovingInfo() {NewPosition = _carInitPosition, Steps = escapeSteps};
            }

            List<string> steps = new List<string>();
            steps.AddRange(escapeSteps);

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
            steps.Add($"{direction}{Math.Abs(lotsToStaircase)}");

            int[] newPosition = (int[]) _carInitPosition.Clone();
            newPosition[0]++;
            newPosition[1] = _stairCasePosition;
            steps.Add("D1");

            return GoDownStair(carParking, newPosition, steps);
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

    class CarMovingInfo
    {
        public CarMovingInfo()
        {
            this.NewPosition = new int[2] {-1, -1};
            this.Steps = new List<string>();
        }

        public int[] NewPosition { get; set; }
        public List<string> Steps { get; set; }
    }
}
