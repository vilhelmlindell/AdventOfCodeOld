using System.Text.RegularExpressions;

namespace AdventOfCode._2021;

public class Day14 : Solver
{
    private Dictionary<string, long> PerformInsertionIterations(Dictionary<string, (string, string)> insertionsByPair,
        Dictionary<string, long> pairCountsByPair,
        long iterations)
    {
        if (iterations == 0) return pairCountsByPair;
        
        var pairsToAdd = new Dictionary<string, long>();
        foreach (KeyValuePair<string, long> pair in pairCountsByPair)
        {
            if (insertionsByPair.ContainsKey(pair.Key))
            {
                string value1 = insertionsByPair[pair.Key].Item1;
                string value2 = insertionsByPair[pair.Key].Item2;
                pairCountsByPair.Remove(pair.Key);

                if (pairsToAdd.ContainsKey(value1))
                    pairsToAdd[value1] += pair.Value;
                else
                    pairsToAdd.Add(value1, pair.Value);

                if (pairsToAdd.ContainsKey(value2))
                    pairsToAdd[value2] += pair.Value;
                else
                    pairsToAdd.Add(value2, pair.Value);
            }
        }

        foreach (KeyValuePair<string, long> pair in pairsToAdd)
        {
            if (pairCountsByPair.ContainsKey(pair.Key))
                pairCountsByPair[pair.Key] += pair.Value;
            else
            {
                pairCountsByPair.Add(pair.Key, pair.Value);
            }
        }

        foreach (KeyValuePair<string, long> pair in pairCountsByPair)
        {
            Console.WriteLine($"({pair.Key}, {pair.Value})");
        }
        
        return PerformInsertionIterations(insertionsByPair, pairCountsByPair, iterations - 1);
    }

    public override string SolvePart1()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2021/Input/Day14.txt").Split('\n');

        string polymer = lines[0];

        var insertionsByPair = new Dictionary<string, (string, string)>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(" -> ");
            insertionsByPair.Add(values[0], (values[0][0] + values[1], values[1] + values[0][1]));
        }

        List<string> pairs = new List<string>();
        for (int i = 0; i < polymer.Length - 1; i++)
        {
            string pair = polymer.Substring(i, 2);
            pairs.Add(pair);
        }

        var pairCountsByPair = new Dictionary<string, long>();

        foreach (string pair in pairs)
        {
            if (!pairCountsByPair.ContainsKey(pair))
                pairCountsByPair.Add(pair, Regex.Matches(polymer, pair).Count());
        }

        PerformInsertionIterations(insertionsByPair, pairCountsByPair, 10);

        var elementCountsByElement = new Dictionary<char, long>();
        
        foreach (KeyValuePair<string, long> pair in pairCountsByPair)
        {
            if (elementCountsByElement.ContainsKey(pair.Key[0]))
                elementCountsByElement[pair.Key[0]] += pair.Value;
            else
                elementCountsByElement.Add(pair.Key[0], pair.Value);
            
            if (elementCountsByElement.ContainsKey(pair.Key[1]))
                elementCountsByElement[pair.Key[1]] += pair.Value;
            else
                elementCountsByElement.Add(pair.Key[1], pair.Value);
        }

        return (1 + (elementCountsByElement.Values.Max() - elementCountsByElement.Values.Min()) / 2).ToString();
    }

    public override string SolvePart2()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2021/Input/Day14.txt").Split('\n');

        string polymer = lines[0];

        var insertionsByPair = new Dictionary<string, (string, string)>();

        for (long i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(" -> ");
            insertionsByPair.Add(values[0], (values[0][0] + values[1], values[1] + values[0][1]));
        }

        List<string> pairs = new List<string>();
        for (int i = 0; i < polymer.Length - 1; i++)
        {
            string pair = polymer.Substring(i, 2);
            pairs.Add(pair);
        }

        var pairCountsByPair = new Dictionary<string, long>();

        foreach (string pair in pairs)
        {
            if (!pairCountsByPair.ContainsKey(pair))
                pairCountsByPair.Add(pair, Regex.Matches(polymer, pair).Count());
        }
        

        PerformInsertionIterations(insertionsByPair, pairCountsByPair, 40);

        var elementCountsByElement = new Dictionary<char, long>();
        
        foreach (KeyValuePair<string, long> pair in pairCountsByPair)
        {
            if (elementCountsByElement.ContainsKey(pair.Key[0]))
                elementCountsByElement[pair.Key[0]] += pair.Value;
            else
                elementCountsByElement.Add(pair.Key[0], pair.Value);
            
            if (elementCountsByElement.ContainsKey(pair.Key[1]))
                elementCountsByElement[pair.Key[1]] += pair.Value;
            else
                elementCountsByElement.Add(pair.Key[1], pair.Value);
        }

        return (1 + (elementCountsByElement.Values.Max() - elementCountsByElement.Values.Min()) / 2).ToString();
    }
}