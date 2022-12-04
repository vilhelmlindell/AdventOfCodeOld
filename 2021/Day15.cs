using System.Runtime.CompilerServices;

namespace AdventOfCode._2021;

public class Day15 : Solver
{
    
    public override string SolvePart1()
    {
        string[] lines = File.ReadAllText(Environment.CurrentDirectory + "/2021/Input/Day15.txt").Split('\n');

        int[,] nodes = new int[lines[0].Length, lines.Length];
        int[,] tentativeDistances = new int[lines[0].Length, lines.Length];
        bool[,] visitedNodes = new bool[lines[0].Length, lines.Length];

        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[0].Length; x++)
            {
                nodes[x, y] = lines[y][x] - '0';
                tentativeDistances[x, y] = Int32.MaxValue;
                visitedNodes[x, y] = false;
            }
        }

        tentativeDistances[0, 0] = 0;
        
        //VisitNode(0, 0);

        return tentativeDistances[99, 99].ToString();
    }

    public override string SolvePart2()
    {
        return "";
    }
}