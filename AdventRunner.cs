using System.Collections.Generic;

using AdventOfCode._2021;
using AdventOfCode._2022;

namespace AdventOfCode;

public static class AdventRunner
{
    private static Dictionary<int, YearRunner> _yearRunners = new Dictionary<int, YearRunner>();

    static AdventRunner()
    {
        _yearRunners[2021] = new Year2021();
        _yearRunners[2022] = new Year2022();
    }

    public static void Run(int year, int day)
    {
        _yearRunners[year].Run(day);
    }
    
    public static void Run(int year)
    {
        _yearRunners[year].Run();
    }

    public static void Run()
    {
        foreach (YearRunner yearRunner in _yearRunners.Values)
            yearRunner.Run();
    }
}
