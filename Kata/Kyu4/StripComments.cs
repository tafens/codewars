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
// SOLUTION


using Kata;
using Kata.Kyu4;


namespace Kata.Kyu4
{
    public class StripComments
    {
        public static string StripTheComments(string text, string[] commentSymbols) {
            return string.Join('\n', text.Split('\n').Select(row => row.Split(commentSymbols, StringSplitOptions.None).FirstOrDefault("").TrimEnd()));
        }

        //public static string StripTheComments(string text, string[] commentSymbols) {
        //    return string.Join('\n', text.Split('\n').Select(row => row.Substring(0, commentSymbols.Select(symbol => row.IndexOf(symbol)).Where(index => index >= 0).OrderBy(index => index).FirstOrDefault(row.Length)).TrimEnd()));
        //}
    }
}
