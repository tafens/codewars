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


// Kata: "Strip Comments" by jhoffner
// UNIT TESTS


using Kata;
using Kata.Kyu4;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    namespace Kyu4
    {
        [TestClass]
        public class StripComments
        {
            [TestMethod]
            public void Test1() {
                string correct="apples, pears\ngrapes\nbananas";
                string result=Kata.Kyu4.StripComments.StripTheComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" });
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test2() {
                string correct="a\nc\nd";
                string result=Kata.Kyu4.StripComments.StripTheComments("a #b\nc\nd $e f g", new string[] { "#", "$" });
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test3() {
                string correct="";
                string result=Kata.Kyu4.StripComments.StripTheComments("a", new string[] { "a" });
                AssertionHelpers.AssertStringsEqual(correct, result);
            }
        }
    }
}
