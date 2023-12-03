public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        var m = text1.Length;
        var n = text2.Length;
        var dp = new int[m + 1][];
        for (int index = 0; index < dp.Length; ++index) {
            dp[index] = new int[n + 1];
        }
        
        for(int index = 1; index <= m; ++index) {
            var letter1 = text1[index - 1];
            for(int search = 1; search <= n; ++search) {
                var letter2 = text2[search - 1];
                if(letter1 == letter2) {
                   dp[index][search] = dp[index - 1][search - 1] + 1; 
                } else {
                    dp[index][search] = Math.Max(dp[index - 1][search], dp[index][search - 1]);
                }
            }
        }
        
        return dp[m][n];        
    }
}