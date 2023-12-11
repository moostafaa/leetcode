public class Solution {
    public int MaxPoints(int[][] points) {
        if (points == null && points.Length == 0) return 0;
        if (points.Length == 1) return 1;

        var maxPoints = 0;
        
        for (int i = 0; i < points.Length; i++) {
            var slopes = new Dictionary<double, int>();
            int duplicate = 1;
            for (int j = 0; j < points.Length; j++) {
                if (i == j) continue;

                if (points[j][0] == points[i][0] && points[j][1] == points[i][1]) {
                    duplicate++;
                    continue;
                }

                double slope = points[j][1] == points[i][1] ? 
                    double.PositiveInfinity : 
                    (double)(points[j][0] - points[i][0]) / (points[j][1] - points[i][1]);

                slopes[slope] = slopes.ContainsKey(slope) ? slopes[slope] + 1 : 1;
            }

            int maxPointsOnLine = slopes.Values.Any() ? slopes.Values.Max() : 0;
            maxPoints = Math.Max(maxPoints, maxPointsOnLine + duplicate);
        }

        return maxPoints;
    }
}

