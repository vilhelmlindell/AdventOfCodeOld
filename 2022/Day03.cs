namespace AdventOfCode._2022;

public class Day03 : Solver
{
    public override string SolvePart1()
    {
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day03.txt")
            .Split('\n')
            .Select(x => (x.Substring(0, x.Length / 2), x.Substring(x.Length / 2, x.Length / 2)))
            .Select(x => x.Item1.Intersect(x.Item2).ElementAt(0))
            .Select(x => char.ToUpper(x) - 64 + (char.IsUpper(x) ? 26 : 0))
            .Sum().ToString();
    }

    public override string SolvePart2()
    {
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day03.txt").Split('\n')
            .Chunk(3)
            .Select(x => x[0].Intersect(x[1]).Intersect(x[2]).ElementAt(0))
            .Select(x => char.ToUpper(x) - 64 + (char.IsUpper(x) ? 26 : 0))
            .Sum().ToString();
    }
}
