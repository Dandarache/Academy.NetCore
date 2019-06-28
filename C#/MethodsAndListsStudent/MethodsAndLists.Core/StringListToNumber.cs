using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToNumber
    {
        public int ElevatorGoUpAndDown(IEnumerable<string> list)
        {
            int currentFloor = 0;

            foreach (var elevatorCommand in list)
            {
                if (elevatorCommand.Equals("upp", StringComparison.CurrentCultureIgnoreCase))
                {
                    currentFloor++;
                }
                else if (elevatorCommand.Equals("ner", StringComparison.CurrentCultureIgnoreCase))
                {
                    currentFloor--;
                }
            }

            return currentFloor;
        }

        public int ElevatorGoUpAndDown_Linq(IEnumerable<string> list)
        {
            int currentFloor = 0;

            int ups = list.Where(a => a.Equals("upp", StringComparison.CurrentCultureIgnoreCase)).Count();
            int downs = list.Count(a => a.Equals("ner", StringComparison.CurrentCultureIgnoreCase));

            currentFloor += ups;
            currentFloor -= downs;

            return currentFloor;
        }

        public int ElevatorGoUpAndDown_Linq_OneLiner(IEnumerable<string> list)
        {
            throw new NotImplementedException();
        }
    }
}
