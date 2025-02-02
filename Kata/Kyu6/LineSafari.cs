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
// SOLUTION


using Kata;
using Kata.Kyu6;


namespace Kata.Kyu6
{
    public class LineSafari
    {
        public static double DistanceFromLine((int, int) a, (int, int) b, (int, int) c) {
            double distance;

            if(a==b) {
                distance = Math.Sqrt(Math.Pow((c.Item1-a.Item1), 2) + Math.Pow((c.Item2-a.Item2), 2));
            } else {
                distance = Math.Abs((b.Item2-a.Item2)*c.Item1 - (b.Item1-a.Item1)*c.Item2 + b.Item1*a.Item2 - b.Item2*a.Item1) /
                           Math.Sqrt(Math.Pow((b.Item2-a.Item2), 2)+Math.Pow((b.Item1-a.Item1), 2));
            }

            return distance;
        }
    }
}
