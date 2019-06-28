using System;
using ElevatorProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ElevatorTest
{
    [TestClass]
    public class UnitTest1
    {
        
        // todo: tydligare pattern Arrange Act Assert

        [TestMethod]
        public void elevator_should_be_at_floor_one_when_thats_its_startfloor()
        {
            var elevator = new Elevator("", lowestFloor:-2, highestFloor:3, startFloor:1, untilMaintainance:6);
            Assert.AreEqual(1, elevator.CurrentFloor);
        }

        [TestMethod]
        public void floor_count_should_be_six_when_bottomfloor_is_negative2_and_topfloor_is_3()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);
            Assert.AreEqual(6, elevator.CountFloors);
        }

        [TestMethod]
        public void elevator_should_be_at_level_2_when_it_starts_at_1_and_go_up_one_floor()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);
            var response = elevator.TryGoUp();
            Assert.AreEqual(2, elevator.CurrentFloor);
            Assert.AreEqual(ElevatorMoveResponse.MoveSuccess, response);
        }

        [TestMethod]
        public void elevator_should_be_at_level_0_when_it_starts_at_1_and_go_down_one_floor()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);

            var response = elevator.TryGoDown();
            Assert.AreEqual(0, elevator.CurrentFloor);
            Assert.AreEqual(ElevatorMoveResponse.MoveSuccess, response);
        }

        [TestMethod]
        public void elevaror_should_be_at_level_3_when_it_starts_at_1_and_go_up_is_called_twice()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);

            elevator.TryGoUp();
            elevator.TryGoUp();
            Assert.AreEqual(3, elevator.CurrentFloor);
        }

        [TestMethod]
        public void elevator_should_be_at_top_floor_when_go_up_is_called_really_many_times()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);

            for (int i=0; i<1000; i++)
                elevator.TryGoUp();

            Assert.AreEqual(3, elevator.CurrentFloor);
        }

        [TestMethod]
        public void elevator_should_be_at_bottom_floor_when_go_down_is_called_really_many_times()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);


            for (int i = 0; i < 100; i++)
                elevator.TryGoDown();

            Assert.AreEqual(-2, elevator.CurrentFloor);
        }

        [TestMethod]
        public void elever_should_still_have_power_after_going_up_and_down_five_times_if_maintainlevel_is_six()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);

            elevator.TryGoDown();
            elevator.TryGoUp();

            elevator.TryGoDown();
            elevator.TryGoUp();

            elevator.TryGoDown();

            Assert.IsTrue(elevator.PowerIsOn);
        }

        [TestMethod]
        public void elever_should_power_down_after_going_up_and_down_six_times_if_maintainlevel_is_six()
        {
            var elevator = new Elevator("", lowestFloor: -2, highestFloor: 3, startFloor: 1, untilMaintainance: 6);

            elevator.TryGoDown();
            elevator.TryGoUp();

            elevator.TryGoDown();
            elevator.TryGoUp();

            elevator.TryGoDown();
            elevator.TryGoUp();

            Assert.IsFalse(elevator.PowerIsOn);
        }

        [TestMethod]
        public void elevator_should_report_that_it_cant_move_when_go_up_signal_on_top_floor()
        {

            var elevator = new Elevator("", lowestFloor: 0, highestFloor: 5, startFloor: 5, untilMaintainance:1000);
            var response = elevator.TryGoUp();
            Assert.AreEqual(ElevatorMoveResponse.CantMoveUp, response);
            Assert.AreEqual(1000, elevator.UntilMaintainance);
        }

        [TestMethod]
        public void elevator_should_report_that_it_cant_move_when_go_down_signal_on_lowest_floor()
        {
            var elevator = new Elevator("", lowestFloor: 0, highestFloor: 5, startFloor: 0, untilMaintainance: 1000);
            var response = elevator.TryGoDown();
            Assert.AreEqual(ElevatorMoveResponse.CantMoveDown, response);
            Assert.AreEqual(1000, elevator.UntilMaintainance);
        }

        [TestMethod]
        public void argumentexception_should_be_raised_when_highest_floor_is_below_lowest_floor()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => new Elevator("", lowestFloor:100, highestFloor: 10));

            Assert.AreEqual(Elevator.ErrorHighestFloorIsTooLow, ex.Message);
        }

        [TestMethod]
        public void argumentexception_should_be_raised_when_start_floor_is_higher_than_top_floor()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => new Elevator("", lowestFloor: 10, highestFloor: 15, startFloor: 15 + 1, untilMaintainance: 1000));

            Assert.AreEqual(Elevator.ErrorStartFloorOutsideOfBounds, ex.Message);
        }


        [TestMethod]
        public void argumentexception_should_be_raised_when_start_floor_is_lower_than_bottom_floor()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => new Elevator("", lowestFloor: 10, highestFloor: 15, startFloor: 10 -1, untilMaintainance: 100));

            Assert.AreEqual(Elevator.ErrorStartFloorOutsideOfBounds, ex.Message);
        }
    }
}
