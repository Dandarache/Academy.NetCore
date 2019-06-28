using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ElevatorProject;

namespace ElevatorConsoleApp
{
    class Program
    {
        static void Main()
        {
            List<Elevator> elevators = LoadElevatorsFromFile();

            while (true)
            {
                DisplayHeader();
                DisplayStatus(elevators);
                Elevator elevator = AskWhichElevatorToMove(elevators);
                Direction direction = AskForDirection();
                ElevatorMoveResponse response;

                if (direction == Direction.Up)
                    response = elevator.TryGoUp();
                else
                    response = elevator.TryGoDown();

                DisplayResponse(response, elevator, direction);

            }

        }



        private static void DisplayResponse(ElevatorMoveResponse? response, Elevator elevator, Direction direction)
        {
            Console.WriteLine();

            switch (response)
            {
                case ElevatorMoveResponse.CantMoveDown:
                    Error("Can't move elevator down");
                    break;
                case ElevatorMoveResponse.CantMoveUp:
                    Error("Can't move elevator up");
                    break;
                case ElevatorMoveResponse.MoveSuccess:
                    string upDown = direction == Direction.Up ? "up" : "down";
                    InfoLine($"Elevator {elevator.Name} will move {upDown} to floor {elevator.CurrentFloor}");
                    break;

                case ElevatorMoveResponse.PowerIsOut:
                    Error("Elevator needs maintainance");
                    break;
                default:
                    throw new Exception("Shouldn't happen");
            }

            Console.ReadKey();
        }


        private static Direction AskForDirection()
        {
            while (true)
            {
                Info("Go up or down? ");
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine()?.ToUpper();
                if (input == "UP")
                    return Direction.Up;
                if (input == "DOWN")
                    return Direction.Down;
            }
        }

        private static Elevator AskWhichElevatorToMove(List<Elevator> elevators)
        {
            while (true)
            {
                Info("Which elevator do you want to move? ");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();
                var elevator = elevators.FirstOrDefault(e => e.Name == input);
                if (elevator != null)
                {
                    return elevator;
                }
            }
        }



        private static void DisplayStatus(List<Elevator> elevators)
        {
            TableHeader("Name".PadRight(5) +
                     "Current".PadLeft(10) +
                     "Lowest".PadLeft(10) +
                     "Highest".PadLeft(10) +
                     "Power".PadLeft(10) +
                     "IsOn".PadLeft(10)
            );

            foreach (var e in elevators)
            {
                string isOn = e.PowerIsOn ? "On" : "Off";
                string row =
                       e.Name.PadRight(5) +
                       e.CurrentFloor.ToString().PadLeft(10) +
                       e.LowestFloor.ToString().PadLeft(10) +
                       e.HighestFloor.ToString().PadLeft(10) +
                       e.UntilMaintainance.ToString().PadLeft(10) +
                       isOn.PadLeft(10)
                    ;
                InfoLine(row);
            }

            Console.WriteLine();
        }

        private static List<Elevator> LoadElevatorsFromFile()
        {
            var result = new List<Elevator>();
            foreach (string row in File.ReadAllLines("elevators.txt"))
            {
                if (string.IsNullOrWhiteSpace(row))
                    continue;

                string[] rowArray = row.Split(",");
                result.Add(
                    new Elevator(
                        rowArray[0],
                        int.Parse(rowArray[2]),
                        int.Parse(rowArray[3]),
                        int.Parse(rowArray[1]),
                        int.Parse(rowArray[4])
                    ));
            }

            return result;
        }

        private static void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine(" ELEVATOR APP");
            Console.WriteLine();
        }

        private static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($" {message}");
        }

        private static void InfoLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($" {message}");
        }

        private static void TableHeader(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {message}");
        }

        private static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" {message}");
        }

    }
}
