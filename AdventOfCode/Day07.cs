using AdventOfCode.Utilities.Extensions;

namespace AdventOfCode;

public class Day07 : BaseDay
{
    public override ValueTask<string> Solve_1()
    {
        var inputRaw = File.ReadAllLines("Inputs/07.txt");
        var input = new char[inputRaw.Length][];

        foreach (var line in inputRaw.WithIndex())
        {
            input[line.Index] = line.Item.ToCharArray();
        }

        var totalSplit = 0;
        var splitIdxSet = new HashSet<int>();

        var startIdx = 0;
        foreach (var c in input[0].WithIndex())
        {
            if (c.Item is 'S' or 's')
            {
                startIdx = c.Index;
            }
        }

        splitIdxSet.Add(startIdx);

        for (var row = 2; row < input.Length; row += 2)
        {
            foreach (var (item, index) in input[row].WithIndex())
            {
                if (item != '^' || !splitIdxSet.Contains(index)) continue;

                totalSplit++;

                splitIdxSet.Remove(index);

                splitIdxSet.Add(index + 1);
                splitIdxSet.Add(index - 1);
            }
        }

        return new ValueTask<string>(totalSplit.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var inputRaw = File.ReadAllLines("Inputs/07.txt");
        var input = new char[inputRaw.Length][];

        foreach (var line in inputRaw.WithIndex())
        {
            input[line.Index] = line.Item.ToCharArray();
        }
        
        var paths = new ulong[input[0].Length];
        
        foreach (var c in input[0].WithIndex())
        {
            if (c.Item is 'S' or 's')
            {
                paths[c.Index] = 1;
            }
        }

        for (var row = 2; row < input.Length; row += 2)
        {
            foreach (var (item, index) in input[row].WithIndex())
            {
                if (item != '^') continue;
                
                paths[index - 1] = paths[index] + paths[index - 1];
                paths[index + 1] = paths[index] + paths[index + 1];

                paths[index] = 0;
            }
        }

        var sum = paths.Aggregate(0UL, (current, val) => current + val);

        return new ValueTask<string>(sum.ToString());
    }
}