namespace AdventOfCode._2022;

public class Day08 : Solver
{
    public override string SolvePart1()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day08.txt").Split('\n');
        var trees = new int[lines[0].Length, lines.Length];
        var visibleTrees = new bool[lines[0].Length, lines.Length];
        int visibleTreeCount = 0;
        for (int x = 0; x < trees.GetLength(0); x++)
        {
            for (int y = 0; y < trees.GetLength(1) - 1; y++)
            {
                trees[x, y] = Convert.ToInt32(lines[y][x]);
            }
        }
        for (int y = 0; y < trees.GetLength(1); y++)
        {
            int tallestTreeLeft = 0;
            int tallestTreeRight = 0;
            for (int x = 0; x < trees.GetLength(0); x++)
            {
                if (trees[x, y] > tallestTreeLeft)
                { 
                    tallestTreeLeft = trees[x, y];
                    if (!visibleTrees[x, y])
                    {
                        visibleTreeCount++;
                    }
                    visibleTrees[x, y] = true;
                }
                if (trees[trees.GetLength(0) - x - 1, y] > tallestTreeRight)
                {
                    tallestTreeRight = trees[trees.GetLength(0) - x - 1, y];
                    if (!visibleTrees[trees.GetLength(0) - x - 1, y])
                    {
                        visibleTreeCount++;
                    }
                    visibleTrees[trees.GetLength(0) - x - 1, y] = true;
                }
            }
        }

        for (int x = 0; x < trees.GetLength(0); x++)
        {
            int tallestTreeTop = 0;
            int tallestTreeBottom = 0;
            for (int y = 0; y < trees.GetLength(1); y++)
            {
                if (trees[x, y] > tallestTreeTop)
                { 
                    tallestTreeTop = trees[x, y];
                    if (!visibleTrees[x, y])
                    {
                        visibleTreeCount++;
                    }
                    visibleTrees[x, y] = true;
                }
                if (trees[x, trees.GetLength(1) - y - 1] > tallestTreeBottom)
                {
                    tallestTreeBottom = trees[x, trees.GetLength(1) - y - 1];
                    if (!visibleTrees[x, trees.GetLength(1) - y - 1])
                    {
                        visibleTreeCount++;
                    }
                    visibleTrees[x, trees.GetLength(1) - y - 1] = true;
                }
            }
        }
        return visibleTreeCount.ToString();
    }

    public override string SolvePart2()
    {
        var lines = File.ReadAllText(Environment.CurrentDirectory + "/2022/Input/Day08.txt").Split('\n');
        var trees = new int[lines[0].Length, lines.Length];
        for (int x = 0; x < trees.GetLength(0); x++)
        {
            for (int y = 0; y < trees.GetLength(1) - 1; y++)
            {
                trees[x, y] = Convert.ToInt32(lines[y][x]);
            }
        }
        int highestScenicScore = 0;
        for (int x = 0; x < trees.GetLength(0); x++)
        {
            for (int y = 0; y < trees.GetLength(1); y++)
            {
                int viewingScoreLeft = 0;
                int viewingScoreRight = 0;
                int viewingScoreUp = 0;
                int viewingScoreDown = 0;
                bool rightOpen = true;
                bool leftOpen = true;
                bool topOpen = true;
                bool bottomOpen = true;
                for (int j = 1; ; j++)
                {
                    int exitCondition = 0;
                    if (x + j < trees.GetLength(0) && rightOpen)
                    {
                        if (trees[x + j, y] < trees[x, y])
                        {
                            exitCondition++;
                        }
                        else
                        {
                            rightOpen = false;
                        }
                        viewingScoreRight++;
                    }
                    if (x - j >= 0 && leftOpen)
                    {
                        if (trees[x - j, y] < trees[x, y])
                        {
                            exitCondition++;
                        }
                        else
                        {
                            leftOpen = false;
                        }
                        viewingScoreLeft++;
                    }
                    if (y + j < trees.GetLength(1) && topOpen)
                    {
                        if (trees[x, y + j] < trees[x, y])
                        {
                            exitCondition++;
                        }
                        else
                        {
                            topOpen = false;
                        }
                        viewingScoreUp++;
                    }
                    if (y - j >= 0 && bottomOpen)
                    {
                        if (trees[x, y - j] < trees[x, y])
                        {
                            exitCondition++;
                        }
                        else
                        {
                            bottomOpen = false;
                        }
                        viewingScoreDown++;
                    }
                    if (exitCondition == 0)
                    {
                        break;
                    }
                }
                int scenicScore = viewingScoreRight * viewingScoreLeft * viewingScoreUp * viewingScoreDown;
                if (scenicScore > highestScenicScore)
                {
                    highestScenicScore = scenicScore;
                }
            }
        }
        return highestScenicScore.ToString();
    }
}
