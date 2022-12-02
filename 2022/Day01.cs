using System.Linq;

namespace AdventOfCode._2022;

public class Day01 : Solver
{
    public override string SolvePart1()
    {
        //string workingDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        //string[] lines = System.IO.File.ReadAllLines(workingDirectory + "/2022/Input/Day01.txt");

        //int highestCalorieCount = 0;
        //int currentCalorieCount = 0;
        //
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    if (lines[i] == "")
        //    {
        //        if (currentCalorieCount > highestCalorieCount)
        //            highestCalorieCount = currentCalorieCount;
        //        currentCalorieCount = 0;
        //        continue;
        //    }

        //    currentCalorieCount += Int32.Parse(lines[i]);
        //}
        //
        //return highestCalorieCount.ToString();
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day01.txt")
            .Split("\r\n\r\n")
            .Select(x => x.Split("\r\n"))
            .Select(x => x.Select(y => Convert.ToInt32(y)).Sum()).MaxBy(x => x)
            .ToString();
    } 
    
    public override string SolvePart2()
    {
        //string[] lines = System.IO.File.ReadAllLines("/2022/Input/Day01.txt");

        //List<int> highestCalorieCounts = new List<int>(4) { 0, 0, 0 };
        //int currentCalorieCount = 0;
        //
        //for (int i = 0; i < lines.Length; i++)
        //{
        //    if (lines[i] == "")
        //    {
        //        int topPosition = -1;
        //        for (int j = 0; j < 3; j++)
        //        {
        //            if (currentCalorieCount >= highestCalorieCounts[j])
        //                topPosition++;
        //        }

        //        if (topPosition != -1)
        //        {
        //            highestCalorieCounts.Insert(topPosition + 1, currentCalorieCount);
        //            highestCalorieCounts.RemoveAt(0);
        //        }

        //        currentCalorieCount = 0;
        //        continue;
        //    }

        //    currentCalorieCount += Int32.Parse(lines[i]);
        //}

        //return highestCalorieCounts.Sum().ToString();
        return File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day01.txt")
            .Split("\n\n")
            .Select(x => x.Split("\r\n"))
            .Select(x => x.Select(y => Convert.ToInt32(y)).Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum()
            .ToString();
    }
}

