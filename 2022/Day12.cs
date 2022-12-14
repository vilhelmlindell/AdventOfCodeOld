namespace AdventOfCode._2022;

public class Day12 : Solver
{
    public override string SolvePart1()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day10.txt").Split('\n');
        var heightMap = lines.Select(x => x.ToCharArray()).ToArray();

        void VisitNeighbours(int x, int y, int distance)
        {
        }
        return "";
    }

    public override string SolvePart2()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day10.txt").Split('\n');
        return "";
    }
}