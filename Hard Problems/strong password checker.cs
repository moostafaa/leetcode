public class Solution {
    private const int MIN_LENGTH = 6;
    private const int MAX_LENGTH = 20;
    private const int MAX_REPEAT_LENGTH = 3;
    
    public int StrongPasswordChecker(string password) {
        bool hasLowerCase = false;
        bool hasUpperCase = false;
        bool hasDigit = false;
        List<int> repeatCharCounts = new List<int>();
        for (int i = 0; i < password.Length; ++i) {
            char c = password[i];
            hasLowerCase |= c >= 'a' && c <= 'z';
            hasUpperCase |= c >= 'A' && c <= 'Z';
            hasDigit |= c >= '0' && c <= '9';
            int repeatLen = 1;
            while (i + 1 < password.Length && password[i + 1] == c) {
                ++i;
                ++repeatLen;
            }
            if (repeatLen >= MAX_REPEAT_LENGTH) {
                repeatCharCounts.Add(repeatLen);
            }
        }
        
        int deletions = 0;
        int passwordCount = password.Length;
        if (passwordCount > MAX_LENGTH) {
            repeatCharCounts = repeatCharCounts.OrderBy(x => x % MAX_REPEAT_LENGTH).ToList();
            while (passwordCount > MAX_LENGTH && repeatCharCounts.Any()) {
                --passwordCount;
                ++deletions;
                var sequence = repeatCharCounts[0];
                if (sequence == MAX_REPEAT_LENGTH) {
                    repeatCharCounts.RemoveAt(0);
                } else if (sequence % MAX_REPEAT_LENGTH == 0) {
                    repeatCharCounts.RemoveAt(0);
                    repeatCharCounts.Insert(repeatCharCounts.Count, sequence - 1);
                } else {
                    repeatCharCounts[0] = sequence - 1;
                }
            }
        }
        if (passwordCount > MAX_LENGTH) {
            deletions += passwordCount - MAX_LENGTH;
        }
        
        int repeatInsertsAndReplaces = 0;
        while (repeatCharCounts.Any()) {
            int count = repeatCharCounts[0];
            repeatCharCounts.RemoveAt(0);
            repeatInsertsAndReplaces += count / MAX_REPEAT_LENGTH;
        }
        
        
        int requiredInsertsOrReplace = (hasLowerCase ? 0 : 1) + (hasUpperCase ? 0 : 1) + (hasDigit ? 0 : 1);
        requiredInsertsOrReplace = password.Length < MIN_LENGTH
            ? Math.Max(MIN_LENGTH - password.Length, requiredInsertsOrReplace)
            : requiredInsertsOrReplace;

        
        int steps = Math.Max(requiredInsertsOrReplace, repeatInsertsAndReplaces) + deletions;
        return steps;
    }
}