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


// Kata: "Line Safari - Point distance to a line" by dinglemouse
// UNIT TESTS


using Kata;
using Kata.Kyu6;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    namespace Kyu6
    {
        [TestClass]
        public class LineSafari
        {
            [TestMethod]
            public void Test1() {
                double correct=15d;
                double result=Kata.Kyu6.LineSafari.DistanceFromLine(a:(10, 10), b:(30, 10), c:(20, 25));
                AssertionHelpers.AssertDoublesEqual(correct, 0.001, result);
            }

            [TestMethod]
            public void Test2AllInLine() {
                double correct=0d;
                double result=Kata.Kyu6.LineSafari.DistanceFromLine(a:(10, 10), b:(70, 70), c:(40, 40));
                AssertionHelpers.AssertDoublesEqual(correct, 0.001, result);
            }

            [TestMethod]
            public void Test3AandBsame() {
                double correct=1.4142136d; // sqrt(2)
                double result=Kata.Kyu6.LineSafari.DistanceFromLine(a:(1, 1), b:(1, 1), c:(2, 2));
                AssertionHelpers.AssertDoublesEqual(correct, 0.001, result);
            }
        }
    }
}
