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
// SOLUTION


using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Kata;
using Kata.Kyu6;


namespace Kata.Kyu6
{
    public class SpeechCorrection
    {
        public static string SaidMeant(HashSet<string> words, string speech) {
            Dictionary<string, string> wordMap;
            string posWord, negWord;

            // generata lookup of each word to its negation and back, and also with 've
            wordMap=new Dictionary<string, string>();
            foreach(string word in words) {
                posWord=word.ToLower(); negWord=(posWord.EndsWith("n") ? posWord+"\'t" : posWord+"n\'t");
                wordMap.Add(posWord, negWord); wordMap.Add(negWord, posWord);
                posWord+="'ve"; negWord+="'ve";
                wordMap.Add(posWord, negWord); wordMap.Add(negWord, posWord);
            }

            // work through each word and swap to its negated form (if applicable) while also preserving case
            return string.Concat(Regex.Split(speech, "([\\w\\']+)").Select(word => wordMap.ContainsKey(word.ToLower()) ? PerserveCase(word, wordMap[word.ToLower()]) : word));
        }

        private static string PerserveCase(string orgWord, string newWord) {
            int orgLen, newLen, i;
            string preservedWord="";

            if(HasAllUpperCaseLetters(orgWord)) { return newWord.ToUpper(); }

            i=0; orgLen=orgWord.Length; newLen=newWord.Length;
            while(i<orgLen && i<newLen && IsSameLetter(orgWord[i], newWord[i])) {
                preservedWord+=orgWord[i]; i++;
            }

            return preservedWord + (newLen>preservedWord.Length ? newWord.Substring(preservedWord.Length) : "");
        }

        private static bool HasAllUpperCaseLetters(string text) =>
            text.All(c => !char.IsLetter(c) || char.IsUpper(c));

        private static bool IsSameLetter(char a, char b) =>
            char.ToUpper(a)==char.ToUpper(b);
    }
}
