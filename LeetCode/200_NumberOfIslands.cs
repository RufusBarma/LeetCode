using Xunit;

namespace NumberOfIslands_200;

public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var islandCount = 0;
        var visited = new HashSet<(int row, int column)>();
        for(var row = 0; row < grid.Length; row++)
            for (var col = 0; col < grid[row].Length; col++)
                if (grid[row][col] == '1' && !visited.Contains((row, col)))
                {
                    VisitWholeIsland(row, col, grid, visited);
                    islandCount++; 
                }
                
        return islandCount;
    }

    private readonly (int row, int col)[] _directions =
    {
        (1, 0), (-1, 0), (0, 1), (0, -1)
    };
    
    private void VisitWholeIsland(int row, int col, char[][] grid, HashSet<(int row, int column)> visited)
    {
        visited.Add((row, col));
        foreach (var nextPoint in _directions
                     .Select(direction =>  (row: row + direction.row, col: col + direction.col))
                     .Where(point =>
                         !visited.Contains(point) &&
                         point.row >= 0 &&
                         point.col >= 0 &&
                         point.row < grid.Length &&
                         point.col < grid[point.row].Length))
        {
            visited.Add(nextPoint);
            if (grid[nextPoint.row][nextPoint.col] == '1')
                VisitWholeIsland(nextPoint.row, nextPoint.col, grid, visited);
        }
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(int expect, char[][] grid)>
        {
            (1, new[]
            {
                new[]{'1','1','1','1','0'},
                new[]{'1','1','0','1','0'},
                new[]{'1','1','0','0','0'},
                new[]{'0','0','0','0','0'},
            }),
        };
        foreach (var test in tests)
        {
            Assert.Equal(test.expect, NumIslands(test.grid));
        }
    }
}