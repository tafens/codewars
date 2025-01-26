using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
