public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k) {
        List<int> result = new List<int>();
    int carry = 0;
    int i = num.Length - 1;
    while (i >= 0 || k > 0 || carry > 0) {
        int digit = carry;
        if (i >= 0) {
            digit += num[i];
            i--;
        }
        if (k > 0) {
            digit += k % 10;
            k /= 10;
        }
        carry = digit / 10;
        digit %= 10;
        result.Insert(0, digit);
    }
    return result.ToArray();
    }
}