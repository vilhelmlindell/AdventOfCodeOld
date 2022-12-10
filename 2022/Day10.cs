namespace AdventOfCode._2022;

public class Day10 : Solver
{
    public override string SolvePart1()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day10.txt").Split('\n');
        int clockCycle = 0;
        int register = 1;
        int signalStrengthSum = 0;
        var cyclesToCheck = new HashSet<int> { 20, 60, 100, 140, 180, 220 };
        foreach (var line in lines)
        {
            if (line == "") continue;
            var sections = line.Split(' ');
            if (sections[0] == "addx")
            {
                for (int i = 0; i < 2; i++)
                {
                    clockCycle++;
                    if (!cyclesToCheck.Contains(clockCycle)) continue;
                    signalStrengthSum += clockCycle * register;
                }

                register += Convert.ToInt32(sections[1]);
            }
            else
            {
                clockCycle++;
                if (!cyclesToCheck.Contains(clockCycle)) continue;
                signalStrengthSum += clockCycle * register;
            }
        }

        return signalStrengthSum.ToString();
    }

    public override string SolvePart2()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day10.txt").Split('\n');
        int clockCycle = 0;
        int register = 1;
        var screen = new char[240].ToList();

        void DrawPixel()
        {
            if (Math.Abs(register - (clockCycle - 1) % 40) <= 1)
            {
                screen[clockCycle - 1] = '#';
            }
            else
            {
                screen[clockCycle - 1] = '.';
            }
        }
        
        foreach (var line in lines)
        {
            if (line == "") continue;
            var sections = line.Split(' ');
            if (sections[0] == "addx")
            {
                for (int i = 0; i < 2; i++)
                {
                    clockCycle++;
                    DrawPixel();
                }

                register += Convert.ToInt32(sections[1]);
            }
            else
            {
                clockCycle++;
                DrawPixel();
            }
        }

        for (int i = 0; i < 6; i++)
        {
            screen.Insert(40 * i + i, '\n');
        }

        return string.Concat(screen);
    }
}