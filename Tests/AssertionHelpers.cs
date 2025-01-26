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


using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    internal static class AssertionHelpers
    {
        public static void AssertStringsEqual(string correct, string result) {
            if(correct!=result) { Assert.Fail($"Strings not equal; correct=\"{correct}\" result=\"{result}\""); }
        }
        
        public static void AssertIntArraysEqual(int[] correct, int[] result) {
            int maxlen;

            maxlen=Math.Max(correct.Length, result.Length);
            for(int i = 0; i<maxlen; i++) {
                if(i>=correct.Length) { Assert.Fail($"Length mismatch: expected={correct.Length}, was={result.Length} (too long); correct={Stringify(correct)}, result={Stringify(result)}"); }
                if(i>=result.Length) { Assert.Fail($"Length mismatch: expected={correct.Length}, was={result.Length} (too short); correct={Stringify(correct)}, result={Stringify(result)}"); }
                if(correct[i]!=result[i]) { Assert.Fail($"Incorrect value at index={i}: expected={correct[i]}, was={result[i]}; correct={Stringify(correct)}, result={Stringify(result)}"); }
            }
        }

        private static string Stringify(object obj) {
            if(obj is int[] array) { return string.Concat("[", string.Join(",", array), "]"); }
            return "";
        }

    }
}
