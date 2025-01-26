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
// UNIT TESTS


using Kata;
using Kata.Kyu3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    namespace Kyu3
    {
        [TestClass]
        public class TheLift
        {
            [TestMethod]
            public void TestEmpty() {
                int[] correct=[0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [], [], [], [], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestUp() {
                int[] correct=[0, 2, 5, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [], [5, 5, 5], [], [], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestDown() {
                int[] correct=[0, 2, 1, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [], [1, 1], [], [], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestUpAndUp() {
                int[] correct=[0, 1, 2, 3, 4, 5, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [3], [4], [], [5], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestDownAndDown() {
                int[] correct=[0, 5, 4, 3, 2, 1, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [0], [], [], [2], [3], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestUpAndDown() {
                int[] correct=[0, 1, 2, 3, 6, 5, 3, 2, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[3], [2], [0], [2], [], [], [5]], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestEnterOnGroundFloor() {
                int[] correct=[0, 1, 2, 3, 4, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[1, 2, 3, 4], [], [], [], [], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestYoYo() {
                int[] correct=[0, 2, 4, 2, 4, 2, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [], [4, 4, 4, 4], [], [2, 2, 2, 2], [], []], 2);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestLiftFullUp() {
                int[] correct=[0, 3, 0, 3, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[3, 3, 3, 3, 3, 3], [], [], [], [], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestLiftFullDown() {
                int[] correct=[0, 3, 1, 3, 1, 3, 1, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [], [], [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1], [], [], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestLiftFullUpAndDown() {
                int[] correct=[0, 3, 5, 4, 0, 3, 5, 4, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[3, 3, 3, 3, 3, 3], [], [], [], [], [4, 4, 4, 4, 4, 4], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestTrickyQueues() {
                int[] correct=[0, 1, 5, 6, 5, 1, 0, 1, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [0, 0, 0, 6], [], [], [], [6, 6, 0, 0, 0, 6], []], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestHighlander() {
                int[] correct=[0, 1, 2, 3, 1, 2, 3, 2, 3, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [2], [3, 3, 3], [1], [], [], []], 1);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }

            [TestMethod]
            public void TestFireDrill() {
                int[] correct=[0, 6, 5, 4, 3, 2, 1, 0, 5, 4, 3, 2, 1, 0, 4, 3, 2, 1, 0, 3, 2, 1, 0, 1, 0];
                int[] result=Kata.Kyu3.TheLift.TheLiftByDingleMouse([[], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]], 5);
                AssertionHelpers.AssertIntArraysEqual(correct, result);
            }
        }
    }
}