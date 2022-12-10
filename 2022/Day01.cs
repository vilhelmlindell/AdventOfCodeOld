namespace AdventOfCode._2022;

public class Day01 : Solver
{
    public override string SolvePart1()
    {
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day01.txt")
            .Split("\n\n")
            .Select(x => x.Split('\n'))
            .Select(x => x.Select(y => Convert.ToInt32(y)).Sum()).MaxBy(x => x)
            .ToString();
    } 
    
    public override string SolvePart2()
    {
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day01.txt")
            .Split("\n\n")
            .Select(x => x.Split('\n'))
            .Select(x => x.Select(y => Convert.ToInt32(y)).Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum()
            .ToString();
    }
}

