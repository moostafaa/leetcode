public class SmallestInfiniteSet
{
    private SortedSet<int> availableNumbers;
    private int nextNumber;

    public SmallestInfiniteSet()
    {
        this.availableNumbers = new SortedSet<int>();
        this.nextNumber = 1;
    }

    public int PopSmallest()
    {
        if (availableNumbers.Count > 0)
        {
            int smallestAvailableNumber = availableNumbers.Min;
            availableNumbers.Remove(smallestAvailableNumber);
            return smallestAvailableNumber;
        }
        else
        {
            return nextNumber++;
        }
    }

    public void AddBack(int num)
    {
        if (num < nextNumber && !availableNumbers.Contains(num))
        {
            availableNumbers.Add(num);
        }
    }
}