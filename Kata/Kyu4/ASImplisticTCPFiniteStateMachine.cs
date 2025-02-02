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
// SOLUTION


using Kata;
using Kata.Kyu4;


namespace Kata.Kyu4
{
    public class ASImplisticTCPFiniteStateMachine
    {
        private static Dictionary<string,Dictionary<string,string>> transitionFromBy=new() {
            ["CLOSED"]      = new() { ["APP_PASSIVE_OPEN"] = "LISTEN",
                                      ["APP_ACTIVE_OPEN"]  = "SYN_SENT" },
            ["LISTEN"]      = new() { ["RCV_SYN"]          = "SYN_RCVD",
                                      ["APP_SEND"]         = "SYN_SENT",
                                      ["APP_CLOSE"]        = "CLOSED" },
            ["SYN_RCVD"]    = new() { ["APP_CLOSE"]        = "FIN_WAIT_1",
                                      ["RCV_ACK"]          = "ESTABLISHED" },
            ["SYN_SENT"]    = new() { ["RCV_SYN"]          = "SYN_RCVD",
                                      ["RCV_SYN_ACK"]      = "ESTABLISHED",
                                      ["APP_CLOSE"]        = "CLOSED" },
            ["ESTABLISHED"] = new() { ["APP_CLOSE"]        = "FIN_WAIT_1",
                                      ["RCV_FIN"]          = "CLOSE_WAIT" },
            ["FIN_WAIT_1"]  = new() { ["RCV_FIN"]          = "CLOSING",
                                      ["RCV_FIN_ACK"]      = "TIME_WAIT",
                                      ["RCV_ACK"]          = "FIN_WAIT_2" },
            ["CLOSING"]     = new() { ["RCV_ACK"]          = "TIME_WAIT" },
            ["FIN_WAIT_2"]  = new() { ["RCV_FIN"]          = "TIME_WAIT" },
            ["TIME_WAIT"]   = new() { ["APP_TIMEOUT"]      = "CLOSED" },
            ["CLOSE_WAIT"]  = new() { ["APP_CLOSE"]        = "LAST_ACK" },
            ["LAST_ACK"]    = new() { ["RCV_ACK"]          = "CLOSED" }
        };
        
        public static string TraverseStates(string[] events) {
            string state="CLOSED"; // initial state

            try {
                foreach(string evt in events) { state=transitionFromBy[state][evt]; }
                return state;
            } catch(KeyNotFoundException) { return "ERROR"; }
        }
    }
}
