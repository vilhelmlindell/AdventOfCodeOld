using System.Text.RegularExpressions;

namespace AdventOfCode._2021;

public class Day14 : Solver
{
    public override string SolvePart1()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2021/Input/Day14.txt").Split('\n');
        
        string polymer = lines[0];
        Dictionary<string, string> insertionsByPair = new Dictionary<string, string>();
        
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(" -> ");
            insertionsByPair.Add(values[0], values[1]);
        }

        for (int i = 0; i < 40; i++)
        {
            Console.WriteLine(i);
            for (int j = 0; j < polymer.Length - 1; j++)
            {
                string pair = polymer.Substring(j, 2);
                if (insertionsByPair.ContainsKey(pair))
                {
                    polymer = polymer.Insert(j + 1, insertionsByPair[pair]);
                    j++;
                }
            }
        }

        var elementCounts = polymer.Distinct().Select(x => polymer.Count(y => y == x));
        return (elementCounts.Max() - elementCounts.Min()).ToString();
    }

    public override string SolvePart2()
    {
        return "";
    }
}