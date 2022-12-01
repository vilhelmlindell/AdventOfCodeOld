namespace AdventOfCode;

public abstract class Solver
{
    public abstract string SolvePart1();
    public abstract string SolvePart2();

    public void Run()
    {
        Console.WriteLine(SolvePart1());
        Console.WriteLine(SolvePart2());
    }
}