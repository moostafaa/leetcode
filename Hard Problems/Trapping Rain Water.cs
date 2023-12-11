//using two pointers
public class Solution
{
	public int Trap(int[] height)
	{
		if(height == null || height.Length < 3) return 0;
		int left = 0, right = height.Length - 1;
		int leftMax = 0, rightMax = 0;;
		int trappedWater = 0;
		while(left < right)
		{
			if(height[left] < height[right])
			{
				if (height[left] >= leftMax)
					leftMax = height[left]; 
				else
					trappedWater += leftMax - height[left];
				left++;
			}
			else
			{
				if (height[right] >= rightMax)
					rightMax = height[right]; 
				else
					trappedWater += rightMax - height[right];
				right--;
			}
		}
		return trappedWater;
	}
}