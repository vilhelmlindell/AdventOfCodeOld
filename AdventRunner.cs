using System.Collections.Generic;
using AdventOfCode._2022;

namespace AdventOfCode;

public static class AdventRunner
{
    private static Solver[] _solvers = new Solver[25];

    static AdventRunner()
    {
        _solvers[0] = new Day01();
        _solvers[1] = new Day02();
    }

    public static void Run(int day)
    {
        _solvers[day - 1].Run();
    }

    public static void Run()
    {
        foreach (Solver solver in _solvers)
            solver.Run();
    }
}