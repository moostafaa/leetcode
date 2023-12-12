public IList<string> FindWords(char[][] board, string[] words)
{
	var trie = new Trie();
	var results = new HashSet<string>();
	foreach(var word in words)
		trie.Insert(word);
	
	for (int i = 0; i < board.Length; i++)
	{
		for (int j = 0; j < board[i].Length; j++)
		{
			Dfs(board, i, j, trie.Root, results);
		}
	}
	
	
	return results.ToList();
}

private void Dfs(char[][] board, int i, int j, TrieNode node, HashSet<string> result)
{
	if(i < 0 || i >= board.Length || j < 0 || j >=board[0].Length || board[i][j] == '#')
		return;
	
	var c = board[i][j];
	node = node.Children[c - 'a'];
	if(node == null) return;
	
	if(node.IsWord) result.Add(node.Word);

	board[i][j] = '#';
	
	board.Dump();
	Dfs(board, i + 1, j, node, result);
	Dfs(board, i - 1, j, node, result);
	Dfs(board, i, j + 1, node, result);
	Dfs(board, i, j - 1, node, result);
	board[i][j] = c;
}
public class TrieNode
{
	public TrieNode[] Children = new TrieNode[26];
	public bool IsWord = false;
	public string Word = "";
}
public class Trie
{
	public TrieNode Root = new TrieNode();

	public void Insert(string word)
	{
		TrieNode node = Root;
		for (int i = 0; i < word.Length; i++)
		{
			char c = word[i];
			if (node.Children[c - 'a'] == null)
			{
				node.Children[c - 'a'] = new TrieNode();
			}
			node = node.Children[c - 'a'];
		}
		node.IsWord = true;
		node.Word = word;
	}
}