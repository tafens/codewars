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
// SOLUTION


using Kata;
using Kata.Kyu6;


namespace Kata.Kyu6
{
    public class SnakesAndLadders
    {
        public static int Play(int[] board, int[] dice) {
            int pos,len,end;

            pos=0; len=board.Length; end=len-1;
            for(int i=0,d=0; i<dice.Length && pos!=end; i++) {
                d=dice[i]; if(pos+d>=len) { continue; }            // throw and check; if too large, rethrow
                pos+=d; while(board[pos]!=0) { pos+=board[pos]; }  // move and walk the snakes and ladders
            }

            return pos;
        }
    }
}
