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


// Kata: "Line Safari - Is that a line?" by dinglemouse
// UNIT TESTS


using Kata;
using Kata.Kyu3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    namespace Kyu3
    {
        [TestClass]
        public class LineSafari
        {
            [TestMethod]
            public void TestLineGood1() {
                bool correct=true;
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["           ",
                                                                "X---------X",
                                                                "           ",
                                                                "           "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineGood2() {
                bool correct=true;
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["     ",
                                                                "  X  ",
                                                                "  |  ",
                                                                "  |  ",
                                                                "  X  "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineGood3() {
                bool correct=true;
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["                    ",
                                                                "     +--------+     ",
                                                                "  X--+        +--+  ",
                                                                "                 |  ",
                                                                "                 X  ",
                                                                "                    "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineGood4() {
                bool correct=true;
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["                     ",
                                                                "    +-------------+  ",
                                                                "    |             |  ",
                                                                " X--+      X------+  ",
                                                                "                     "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineGood5() {
                bool correct=true;
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["                      ",
                                                                "   +-------+          ",
                                                                "   |      +++---+     ",
                                                                "X--+      +-+   X     "]));
                Assert.IsTrue(result==correct);
            }


            [TestMethod]
            public void TestLineBad1() {
                bool correct=false; // BAD: invalid step inside line
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["X-----|----X"]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineBad2() {
                bool correct=false; // BAD: corner without a turn
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid([" X  ",
                                                                " |  ",
                                                                " +  ",
                                                                " X  "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineBad3() {
                bool correct=false; // BAD: cannot change direction without a corner
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["   |--------+    ",
                                                                "X---        ---+ ",
                                                                "               | ",
                                                                "               X "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineBad4() {
                bool correct=false; // BAD: ending without X / missing line steps
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["              ",
                                                                "   +------    ",
                                                                "   |          ",
                                                                "X--+      X   ",
                                                                "              "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineBad5() {
                bool correct=false; // BAD: not allowed to visit same tile twice
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["      +------+",
                                                                "      |      |",
                                                                "X-----+------+",
                                                                "      |       ",
                                                                "      X       "]));
                Assert.IsTrue(result==correct);
            }

            [TestMethod]
            public void TestLineBad6() {
                bool correct=false; // BAD: ambiguous
                bool result=Kata.Kyu3.LineSafari.Line(MakeGrid(["X-----+",
                                                                "X     |",
                                                                "|     |",
                                                                "|     |",
                                                                "+-----+"]));
                Assert.IsTrue(result==correct);
            }


            private char[][] MakeGrid(string[] rows) {
                int w,h;

                w=rows.Max(row => row.Length); h=rows.Length;
                return rows.Select(row => row.ToCharArray()).ToArray();
            }
        }
    }
}
