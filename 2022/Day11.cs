using System.Globalization;

namespace AdventOfCode._2022;

public class Day11 : Solver
{
    private record Monkey(List<int> Items,
        Func<double, double> Operation,
        int TestDenominator,
        int MonkeyToPassIfTrue,
        int MonkeyToPassIfFalse);
    
    public override string SolvePart1()
    {
        var monkeyNotes = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day11.txt").Split("\n\n");
        var monkeys = new List<Monkey>();
        
        foreach (string monkeyNote in monkeyNotes)
        {
            string[] lines = monkeyNote.Split('\n');
            List<int> items = lines[1].Split(": ").Last().Split(", ").Select(int.Parse).ToList(); 
            List<string> operationSymbols = lines[2].Split(' ').TakeLast(2).ToList();
            string operatorSymbol = operationSymbols.First();
            bool isNumeric = int.TryParse(operationSymbols.Last(), out int number);
            Func<double, double> operation = operatorSymbol == "+"
                ? x => x + (isNumeric ? number : x)
                : x => x * (isNumeric ? number : x);
            int testDenominator = int.Parse(lines[3].Split(' ').Last());
            int monkeyToPassIfTrue = int.Parse(lines[4].Split(' ').Last());
            int monkeyToPassIfFalse = int.Parse(lines[5].Split(' ').Last());

            monkeys.Add(new Monkey(items, operation, testDenominator, monkeyToPassIfTrue, monkeyToPassIfFalse));
        }
        
        var inspectionCounts = new int[monkeys.Count];

        for (int round = 0; round < 20; round++)
        {
            for (int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
            {
                Monkey monkey = monkeys[monkeyIndex];
                foreach (int worryLevel in monkey.Items)
                {
                    int newWorryLevel = (int)monkey.Operation(worryLevel) / 3;
                    if (newWorryLevel % monkey.TestDenominator == 0)
                    {
                        monkeys[monkey.MonkeyToPassIfTrue].Items.Add(newWorryLevel);
                    }
                    else
                    {
                        monkeys[monkey.MonkeyToPassIfFalse].Items.Add(newWorryLevel);
                    }
                }

                inspectionCounts[monkeyIndex] += monkey.Items.Count;
                monkey.Items.Clear();
            }
        }
        Array.Sort(inspectionCounts);
        int monkeyBusiness = inspectionCounts[^1] * inspectionCounts[^2];
        return monkeyBusiness.ToString();
    }

    public override string SolvePart2()
    {
        var monkeyNotes = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day11.txt").Split("\n\n");
        var monkeys = new List<Monkey>();
        
        foreach (string monkeyNote in monkeyNotes)
        {
            string[] lines = monkeyNote.Split('\n');
            List<int> items = lines[1].Split(": ").Last().Split(", ").Select(int.Parse).ToList(); 
            List<string> operationSymbols = lines[2].Split(' ').TakeLast(2).ToList();
            string operatorSymbol = operationSymbols.First();
            bool isNumeric = int.TryParse(operationSymbols.Last(), out int number);
            Func<double, double> operation = operatorSymbol == "+"
                ? x => x + (isNumeric ? number : x)
                : x => x * (isNumeric ? number : x);
            int testDenominator = int.Parse(lines[3].Split(' ').Last());
            int monkeyToPassIfTrue = int.Parse(lines[4].Split(' ').Last());
            int monkeyToPassIfFalse = int.Parse(lines[5].Split(' ').Last());

            monkeys.Add(new Monkey(items, operation, testDenominator, monkeyToPassIfTrue, monkeyToPassIfFalse));
        }
        
        var inspectionCounts = new int[monkeys.Count];
        double lowestCommonDenominator = 1;
        foreach (Monkey monkey in monkeys)
        {
            lowestCommonDenominator *= monkey.TestDenominator;
        }

        for (int round = 0; round < 10000; round++)
        {
            for (int monkeyIndex = 0; monkeyIndex < monkeys.Count; monkeyIndex++)
            {
                Monkey monkey = monkeys[monkeyIndex];
                foreach (int worryLevel in monkey.Items)
                {
                    int newWorryLevel = (int)(monkey.Operation(worryLevel) % lowestCommonDenominator);
                    if (newWorryLevel % monkey.TestDenominator == 0)
                    {
                        monkeys[monkey.MonkeyToPassIfTrue].Items.Add(newWorryLevel);
                    }
                    else
                    {
                        monkeys[monkey.MonkeyToPassIfFalse].Items.Add(newWorryLevel);
                    }
                }

                inspectionCounts[monkeyIndex] += monkey.Items.Count;
                monkey.Items.Clear();
            }
        }
        Array.Sort(inspectionCounts);
        double monkeyBusiness = (double)inspectionCounts[^1] * inspectionCounts[^2];
        return monkeyBusiness.ToString(CultureInfo.InvariantCulture);
    }
}