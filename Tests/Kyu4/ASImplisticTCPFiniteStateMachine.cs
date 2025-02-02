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


// Kata: "A Simplistic TCP Finite State Machine (FSM)" by oldccoder
// UNIT TESTS


using Kata;
using Kata.Kyu4;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.Kyu4
{
    [TestClass]
    public class ASImplisticTCPFiniteStateMachine
    {
        [TestMethod]
        public void Test1() {
            string correct="CLOSE_WAIT";
            string result=Kata.Kyu4.ASImplisticTCPFiniteStateMachine.TraverseStates(["APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN"]);
            AssertionHelpers.AssertStringsEqual(correct, result);
        }

        [TestMethod]
        public void Test2() {
            string correct="ESTABLISHED";
            string result=Kata.Kyu4.ASImplisticTCPFiniteStateMachine.TraverseStates(["APP_PASSIVE_OPEN", "RCV_SYN", "RCV_ACK"]);
            AssertionHelpers.AssertStringsEqual(correct, result);
        }

        [TestMethod]
        public void Test3() {
            string correct="LAST_ACK";
            string result=Kata.Kyu4.ASImplisticTCPFiniteStateMachine.TraverseStates(["APP_ACTIVE_OPEN", "RCV_SYN_ACK", "RCV_FIN", "APP_CLOSE"]);
            AssertionHelpers.AssertStringsEqual(correct, result);
        }

        [TestMethod]
        public void Test4() {
            string correct="SYN_SENT";
            string result=Kata.Kyu4.ASImplisticTCPFiniteStateMachine.TraverseStates(["APP_ACTIVE_OPEN"]);
            AssertionHelpers.AssertStringsEqual(correct, result);
        }

        [TestMethod]
        public void Test5() {
            string correct="ERROR";
            string result=Kata.Kyu4.ASImplisticTCPFiniteStateMachine.TraverseStates(["RCV_SYN", "RCV_ACK", "APP_CLOSE", "APP_SEND"]);
            AssertionHelpers.AssertStringsEqual(correct, result);
        }
    }
}
