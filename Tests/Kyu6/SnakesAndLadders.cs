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


// Kata: "Snakes & Ladders" by dinglemouse
// UNIT TESTS


using Kata;
using Kata.Kyu6;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    namespace Kyu6
    {
        [TestClass]
        public class SnakesAndLadders
        {
            [TestMethod]
            public void Test1() {
                int correct=10;
                int result=Kata.Kyu6.SnakesAndLadders.Play(board:[ 0, 0, 3, 0, 0, 0, 0, -2, 0, 0, 0 ], dice:[ 2, 1, 5, 1, 5, 4 ]);
                Assert.IsTrue(result==correct);
            }
        }
    }
}
