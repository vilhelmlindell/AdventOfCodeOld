namespace AdventOfCode._2022;

public class Day02 : Solver
{
    public override string SolvePart1()
    {
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day02.txt")
            .Split('\n')
            .Select(x => x.Split(' '))
            .Select(x => x.Select(y => y is "A" or "X" ?
                                              1 : y is "B" or "Y" ? 2 : 3))
            .Select(x => x.ElementAt(1) + (x.ElementAt(1) - x.ElementAt(0) == 0 ? 3 : 
                                      (x.ElementAt(1) - x.ElementAt(0) == 1 || 
                                       x.ElementAt(1) - x.ElementAt(0) == -2) ? 6 : 0))
            .Sum()
            .ToString();
}

    public override string SolvePart2()
    {
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day02.txt")
            .Split('\n')
            .Select(x => x.Split(' '))
            .Select(x => (x.ElementAt(0) is "A" ?
                    1 : x.ElementAt(0) is "B" ? 2 : 3, x.ElementAt(1)))
            .Select(x => (x.Item2 == "Y" ? x.Item1 + 3 :
                                 x.Item2 == "X" ? (x.Item1 == 1 ? 3 : x.Item1 - 1) 
                               : (x.Item1 == 3 ? 1 + 6 : x.Item1 + 1 + 6)))
            .Sum()
            .ToString();
                
    }
}