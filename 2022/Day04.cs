namespace AdventOfCode._2022;

public class Day04 : Solver
{
    public override string SolvePart1()
    {
        var pairs = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day04.txt")
            .Split('\n')
            .Select(x => x.Split(','))
            .Select(x => (x.ElementAt(0).Split('-'), x.ElementAt(1).Split('-')))
            .Select(x => (x.Item1.Select(y => Convert.ToInt32(y)), x.Item2.Select(y => Convert.ToInt32(y))))
            .Select(x => ((x.Item1.ElementAt(0), x.Item1.ElementAt(1)), (x.Item2.ElementAt(0), x.Item2.ElementAt(1))));

        int count = 0;
        
        foreach (var pair in pairs)
        {
            if ((pair.Item1.Item1 >= pair.Item2.Item1 && pair.Item1.Item2 <= pair.Item2.Item2) ||
                (pair.Item2.Item1 >= pair.Item1.Item1 && pair.Item2.Item2 <= pair.Item1.Item2))
            {
                count++;
            }
            
        }

        return count.ToString();
    }

    public override string SolvePart2()
    {
        var pairs = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day04.txt")
            .Split('\n')
            .Select(x => x.Split(','))
            .Select(x => (x.ElementAt(0).Split('-'), x.ElementAt(1).Split('-')))
            .Select(x => (x.Item1.Select(y => Convert.ToInt32(y)), x.Item2.Select(y => Convert.ToInt32(y))))
            .Select(x => ((x.Item1.ElementAt(0), x.Item1.ElementAt(1)), (x.Item2.ElementAt(0), x.Item2.ElementAt(1))));

        int count = 0;
        
        foreach (var pair in pairs)
        {
            if (Enumerable.Range(pair.Item1.Item1, pair.Item1.Item2 - pair.Item1.Item1 + 1)
                    .Intersect(Enumerable.Range(pair.Item2.Item1, pair.Item2.Item2 - pair.Item2.Item1 + 1)).Count() > 0)
            {
                count++;
            }
            
        }

        return count.ToString();
    }
}
