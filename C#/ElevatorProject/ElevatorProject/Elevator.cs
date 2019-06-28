using System;

namespace ElevatorProject
{
    public class Elevator
    {
        public string Name { get; }
        public int LowestFloor { get; }
        public int HighestFloor { get; }

        public int CurrentFloor { get; private set; }
        public int UntilMaintainance { get; private set; }

        public int CountFloors => HighestFloor - LowestFloor + 1; // används bara i testet

        public bool PowerIsOn => UntilMaintainance > 0;

        // todo: enum av felkoderna (och texterna nånannanstans)

        public static string ErrorStartFloorOutsideOfBounds = "Start floor has to be between lowest floor and highest floor";

        public static string ErrorHighestFloorIsTooLow = "Highest floor can't be lower than lowest floor";

        // todo: eget ElevatorException?

        public Elevator(string name, int lowestFloor, int highestFloor, int startFloor, int untilMaintainance)
        {
            if (highestFloor < lowestFloor)
                throw new ArgumentException(ErrorHighestFloorIsTooLow);

            if (startFloor < lowestFloor || startFloor > highestFloor)
                throw new ArgumentException(ErrorStartFloorOutsideOfBounds);

            if (untilMaintainance<0)
                throw new ArgumentException();

            Name = name;
            LowestFloor = lowestFloor;
            HighestFloor = highestFloor;
            CurrentFloor = startFloor;
            UntilMaintainance = untilMaintainance;
        }


        public Elevator(string name, int lowestFloor, int highestFloor):this(name, lowestFloor, highestFloor, lowestFloor, 10)
        {
        }

        public ElevatorMoveResponse TryGoUp()
        {
            if (!PowerIsOn)
                return ElevatorMoveResponse.PowerIsOut;

            if (CurrentFloor >= HighestFloor)
                return ElevatorMoveResponse.CantMoveUp;
            CurrentFloor++;
            WearAndTear();
            return ElevatorMoveResponse.MoveSuccess;
        }

        public ElevatorMoveResponse TryGoDown()
        {
            if (!PowerIsOn)
                return ElevatorMoveResponse.PowerIsOut;

            if (CurrentFloor <= LowestFloor)
                return ElevatorMoveResponse.CantMoveDown;
            CurrentFloor--;
            WearAndTear();
            return ElevatorMoveResponse.MoveSuccess;
        }

        private void WearAndTear()
        {
            if (UntilMaintainance > 0)
                UntilMaintainance--;
        }


    }
}
