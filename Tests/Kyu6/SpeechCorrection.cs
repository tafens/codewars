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


// Kata: "I said the word WOULD instead of WOULDN'T" by dinglemouse
// UNIT TESTS


using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kata;
using Kata.Kyu6;


namespace Tests
{
    namespace Kyu6
    {
        [TestClass]
        public class SpeechCorrection
        {
            [TestMethod]
            public void Test1() {
                string correct="I don't like pizza.";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "I do like pizza.");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test2() {
                string correct="I haven't seen you wearing that hat before.";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "I have seen you wearing that hat before.");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test3() {
                string correct="I could see why you would say that.";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "I could see why you wouldn't say that.");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test4() {
                string correct="I didn't say it! It wasn't me!";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "I didn't say it! It was me!");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test5() {
                string correct="I must be more careful in future.";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "I must be more careful in future.");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test6() {
                string correct="YES, WE CAN";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "YES, WE CAN'T");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test7() {
                string correct="Wouldn't you believe it? I can't!";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "Would you believe it? I can!");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void Test8() {
                string correct="I don't see why it WOULD be them";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "do", "have", "was", "would"], "I do see why it WOULDN'T be them");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }


            [TestMethod]
            public void TestA() {
                string correct="I couldn't've done better.";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "could"], "I could've done better.");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void TestB() {
                string correct="I think I can't, I think I Can't, I think I cAN't. I CAN'T!";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "could"], "I think I can, I think I Can, I think I cAN. I CAN!");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }

            [TestMethod]
            public void TestC() {
                string correct="CAN CAN've CAN CAN'VE";
                string result=Kata.Kyu6.SpeechCorrection.SaidMeant(["can", "could"], "CAN't CAN'T've CAN'T CAN'T'VE");
                AssertionHelpers.AssertStringsEqual(correct, result);
            }
        }
    }
}
