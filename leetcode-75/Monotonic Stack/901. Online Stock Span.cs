//using stack
public class StockSpanner
{

	Stack<(int stock, int CorrespondingSpan)> items = new Stack<(int stock, int CorrespondingSpan)>();

	public StockSpanner()
	{

	}

	public int Next(int price)
	{
		var span = 1;
		while(items.Count > 0 && items.Peek().stock <= price)
		{
			var item = items.Pop();
			span+=item.CorrespondingSpan;
		}
		items.Push(new(price, span));
		return span;
	}
}

//without stack, slow approach
public class StockSpanner
{
	
	List<int> items = new List<int>();
	
	public StockSpanner()
	{
		
	}

	public int Next(int price)
	{
		int span = 0;
		for (int i = 0; i < items.Count; i++)
		{
			if(items[i] <= price) span++;
			else span = 0;
		}
		items.Add(price);
		return span+1;
	}
}