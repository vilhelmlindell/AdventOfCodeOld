namespace AdventOfCode;

public abstract class Solver
{
    public abstract string Solve();

    public void Run()
    {
        string answer = Solve();
        Console.WriteLine(answer);
    }
}