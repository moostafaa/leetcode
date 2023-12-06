public class Solution
{
	public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
	{
		TrieNode node = new TrieNode();
		Array.Sort(products);
		foreach (var product in products)
		{
			node.Insert(product);
		}
		
		var result= new List<IList<string>>();
		string prefix = string.Empty;
		foreach (var c in searchWord)
		{
			prefix += c;
			result.Add(node.Search(prefix));
		}
		return result;
	}
}

public class TrieNode
{
	public SortedDictionary<char, TrieNode> children;
	public List<string> Starts;
	
	public TrieNode()
	{
		children = new SortedDictionary<char, TrieNode>();
		Starts = new List<string>();
	}
	
	public void Insert(string word)
	{
		TrieNode node = this;
		foreach (var ch in word)
		{
			if (!node.children.ContainsKey(ch))
				node.children[ch] = new TrieNode();
			node = node.children[ch];
			if(node.Starts.Count < 3)
				node.Starts.Add(word);
		}
	}
	
	public List<string> Search(string prefix)
	{
		TrieNode node = this;
		foreach (var ch in prefix)
		{
			if(!node.children.ContainsKey(ch))
				return new List<string>();
			node = node.children[ch];
		}
		return node.Starts;
	}
}