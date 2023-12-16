public class Solution {
    public int NumUniqueEmails(string[] emails) {
        HashSet<string> resultSet = new HashSet<string>();
	foreach (var element in emails)
	{
		var indx = element.LastIndexOf('@');
		var localName = element.Substring(0, indx);
		var domainName = element.Substring(indx + 1, element.Length - indx - 1);
		string clearedLocalName = string.Empty;
		var builder= new StringBuilder();
		foreach (var c in localName)
		{
			if(c == '+')break;
			if(c == '.')continue;
			builder.Append(c);
		}
		clearedLocalName = builder.ToString() + "@" + domainName;
		if(!resultSet.Contains(clearedLocalName))
			resultSet.Add(clearedLocalName);
	}
	return resultSet.Count;
    }
}