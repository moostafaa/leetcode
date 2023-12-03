public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visited = new bool[rooms.Count()];
        //Dfs(0, visited, rooms);

        visited[0] = true;
        var stack = new Stack<int>();
        stack.Push(0);

        while (stack.Count != 0)
        {
            var node = stack.Pop();
            foreach(var key in rooms[node])
                if(!visited[key])
                {
                    visited[key] = true;
                    stack.Push(key);
                }
        }

        return visited.All(x => x);
    }

    void Dfs(int room, bool[] visited, IList<IList<int>> rooms)
    {
        visited[room] = true;
        foreach(var key in rooms[room])
            if(!visited[key]) Dfs(key, visited, rooms);
    }
}