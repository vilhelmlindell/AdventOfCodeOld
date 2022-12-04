namespace AdventOfCode._2022;

public class Day04 : Solver
{
    public override string SolvePart1()
    {
        var pairs = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day03.txt")
            .Split('\n')
            .Select(x => x.Split(','))
            .Select(x => (x.ElementAt(0).Split('-'), x.ElementAt(1).Split('-')))
            .Select(x => (x.Item1.Select(y => Convert.ToInt32(y)), x.Item2.Select(y => Convert.ToInt32(y))));

        foreach (var pair in pairs)
        {
            
        }
    }

    public override string SolvePart2()
    {
    }
}