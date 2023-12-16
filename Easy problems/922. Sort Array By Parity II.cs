public class Solution {
    public int[] SortArrayByParityII(int[] nums) {
int[] result = new int[nums.Length];
	
	int indx = -1, e = 0, o = 1;
	while (++indx < nums.Length)
	{
		if ((nums[indx] & 1) == 1)
		{
			result[o] = nums[indx];
			o+=2;
		}
		else
		{
			result[e] = nums[indx];
			e+=2;
		}
	}
	
	return result;
    }
}