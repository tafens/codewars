//
// This file is part of Stefan Haglund's CodeWars Kata Solutions Collection (SHCKSC),
// written and maintained by Stefan Haglund (stefan.haglund@me.com).
//
// SHCKSC is free software: you can redistribute it and/or modify it under the terms
// of the GNU General Public License as published by the Free Software Foundation,
// either version 3 of the License, or (at your option) any later version.
//
// SHCKSC is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program.
// If not, see <https://www.gnu.org/licenses/>.
//
//-------------------------------------------------------------------------------------------------


// Kata: "The Lift" by dinglemouse
// SOLUTION


using Kata;
using Kata.Kyu3;


namespace Kata.Kyu3
{
    public class TheLift
    {
        public class Lift
        {
            public int Capacity { get; }
            public List<int> People { get; }

            public int Floor { get; private set; }
            public int Direction { get; private set; }


            public bool IsEmpty { get { return (this.People.Count<=0); } }
            public bool IsFull { get { return (this.People.Count>=this.Capacity); } }

            public bool HasDestinationsInCurrentDirection {
                get { return (Direction>0 ? People.Any(x => x>Floor) : People.Any(x => x<Floor)); }
            }
            public int NextDestinationInCurrentDirection {
                get { return (Direction>0 ? People.OrderBy(x => x).FirstOrDefault(x => x>Floor, -1) :
                                            People.OrderByDescending(x => x).FirstOrDefault(x => x<Floor, -1));  }
            }

            public Lift(int capacity) {
                this.Capacity=capacity;
                this.People=new List<int>();
                this.Floor=0; this.Direction=1;
            }


            public void SwitchDirection() {
                Direction=-Direction;
            }
            public void SetDirectionDown() {
                Direction=-1;
            }

            public void Move() {
                this.Floor+=this.Direction;
            }


            public void Enter(int destination) {
                if(IsFull) { throw new Exception("Lift is full"); }
                People.Add(destination);
            }

            public void ExitAll(int destination) {
                if(IsEmpty) { throw new Exception("Lift is empty"); }
                People.RemoveAll(destination => destination==this.Floor);
            }
        }

        private class LiftController
        {
            public LiftController() {

            }

            public List<int> RunLift(Lift lift, List<int>[] calls, int minFloor, int maxFloor) {
                int next; List<int> trace;

                next=0; trace=new List<int>(); trace.Add(lift.Floor);
                while(true) {
                    // EXIT/ENTER PEOPLE
                    // exit people now at their destination floor
                    if(!lift.IsEmpty) { lift.ExitAll(lift.Floor); }
                    // change direction if empty and no more calls in current direction
                    if(lift.IsEmpty &&
                       !HasCallsOnFloorGoingSameWay(calls, lift.Direction, lift.Floor) &&
                       !HasCallsOnOtherFloorsInSameDirectionGoingAnyWay(calls, lift.Direction, minFloor, lift.Floor, maxFloor)) { lift.SwitchDirection(); }
                    // enter people waiting to go in the current direction (if any) until full
                    if(calls[lift.Floor].Count>0) {
                        foreach(int call in calls[lift.Floor].ToList()) {
                            if(lift.IsFull) { break; }
                            if((lift.Direction>0 ? call>lift.Floor : call<lift.Floor)) { lift.Enter(call); calls[lift.Floor].Remove(call); }
                        }
                    }

                    // CHECK DESTINATION
                    next=FindNextDestination(lift, calls, minFloor, maxFloor);
                    if(lift.IsEmpty && lift.Floor==0 && next==0) { break; } // all done

                    // MOVE (at least one floor)
                    do { lift.Move(); } while(lift.Floor!=next && !HasCallsOnFloorGoingSameWay(calls, lift.Direction, lift.Floor));

                    // STOP/OPEN DOORS
                    trace.Add(lift.Floor);
                }

                return trace;
            }


            private int FindNextDestination(Lift lift, List<int>[] calls, int minFloor, int maxFloor) {
                int direction, currentFloor;

                direction=lift.Direction;
                currentFloor=lift.Floor;

                if(!lift.IsEmpty) {
                    // 1a) The Lift never changes direction until there are no more people wanting to get off in the direction it is already travelling
                    if(lift.HasDestinationsInCurrentDirection) { return lift.NextDestinationInCurrentDirection; }
                    // 1b) The Lift never changes direction until there are no more people wanting to get on in the direction it is already travelling
                    if(HasCallsInSameDirectionGoingSameWay(calls, direction, minFloor, currentFloor, maxFloor)) {
                        return NextCallInSameDirectionGoingSameWay(calls, direction, minFloor, currentFloor, maxFloor);
                    }
                    // there are people in the lift, but no more people that wants to get on/off in the current direction
                    lift.SwitchDirection(); return lift.NextDestinationInCurrentDirection;
                } else {
                    // 2) When empty the Lift tries to be smart;
                    // If it was going up then it will continue up to collect the highest floor person wanting to go down
                    // If it was going down then it will continue down to collect the lowest floor person wanting to go up
                    if(HasCallsInSameDirectionGoingOtherWay(calls, direction, minFloor, currentFloor, maxFloor)) {
                        return NextCallInSameDirectionGoingOtherWay(calls, direction, minFloor, currentFloor, maxFloor);
                    }
                    if(HasCallsInSameDirectionGoingSameWay(calls, direction, minFloor, currentFloor, maxFloor)) {
                        return NextCallInSameDirectionGoingSameWay(calls, direction, minFloor, currentFloor, maxFloor);
                    }
                    // 3) If the lift is empty, and no people are waiting, then it will return to the ground floor
                    lift.SetDirectionDown();
                    return 0;
                }
            }

            private bool HasCallsOnFloorGoingSameWay(List<int>[] calls, int direction, int currentFloor) {
                if(direction>0) {
                    if(calls[currentFloor].Any(x => x>currentFloor)) { return true; }
                } else {
                    if(calls[currentFloor].Any(x => x<currentFloor)) { return true; }
                }
                return false;
            }

            private bool HasCallsOnOtherFloorsInSameDirectionGoingAnyWay(List<int>[] calls, int direction, int minFloor, int currentFloor, int maxFloor) {
                if(direction>0) {
                    for(int f = currentFloor+1; f<=maxFloor; f++) { if(calls[f].Any()) { return true; } }
                } else {
                    for(int f = currentFloor-1; f>=minFloor; f--) { if(calls[f].Any()) { return true; } }
                }
                return false;
            }

            private bool HasCallsInSameDirectionGoingSameWay(List<int>[] calls, int direction, int minFloor, int currentFloor, int maxFloor) {
                if(direction>0) {
                    for(int f = currentFloor; f<=maxFloor; f++) { if(calls[f].Any(x => x>f)) { return true; } }
                } else {
                    for(int f = currentFloor; f>=minFloor; f--) { if(calls[f].Any(x => x<f)) { return true; } }
                }
                return false;
            }

            private bool HasCallsInSameDirectionGoingOtherWay(List<int>[] calls, int direction, int minFloor, int currentFloor, int maxFloor) {
                if(direction>0) {
                    for(int f = currentFloor; f<=maxFloor; f++) { if(calls[f].Any(x => x<f)) { return true; } }
                } else {
                    for(int f = currentFloor; f>=minFloor; f--) { if(calls[f].Any(x => x>f)) { return true; } }
                }
                return false;
            }

            private int NextCallInSameDirectionGoingSameWay(List<int>[] calls, int direction, int minFloor, int currentFloor, int maxFloor) {
                int next;

                if(direction>0) {
                    for(int f = currentFloor; f<=maxFloor; f++) {  next=calls[f].Where(x => x>f).OrderBy(x => x).FirstOrDefault(-1); if(next>=0) { return f; } }
                } else {
                    for(int f = currentFloor; f>=minFloor; f--) {  next=calls[f].Where(x => x<f).OrderByDescending(x => x).FirstOrDefault(-1); if(next>=0) { return f; }  }
                }
                return 0;
            }

            private int NextCallInSameDirectionGoingOtherWay(List<int>[] calls, int direction, int minFloor, int currentFloor, int maxFloor) {
                int next;

                if(direction>0) {
                    for(int f = maxFloor; f>=currentFloor; f--) { next=calls[f].Where(x => x<f).OrderBy(x => x).FirstOrDefault(-1); if(next>=0) { return f; } }
                } else {
                    for(int f = minFloor; f<=currentFloor; f++) { next=calls[f].Where(x => x>f).OrderByDescending(x => x).FirstOrDefault(-1); if(next>=0) { return f; } }
                }
                return 0;
            }
        }

        public static int[] TheLiftByDingleMouse(int[][] queues, int capacity) {
            List<int>[] callsByFloor; int minFloor, maxFloor;
            Lift lift; LiftController controller;

            minFloor=0; maxFloor=queues.Length-1; callsByFloor=new List<int>[maxFloor+1];
            for(int f = 0; f<=maxFloor; f++) { callsByFloor[f]=new List<int>(); }

            for(int from = 0; from<=maxFloor; from++) {
                for(int call = 0, to = 0; call<queues[from].Length; call++) {
                    to=queues[from][call]; if(to!=from) { callsByFloor[from].Add(to); }
                }
            }

            lift=new Lift(capacity);

            controller=new LiftController();
            return controller.RunLift(lift, callsByFloor, minFloor, maxFloor).ToArray();
        }
    }
}
