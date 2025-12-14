using AdventOfCode.Utilities.Extensions;

namespace AdventOfCode;

public class Day06 : BaseDay
{
    private string[][] GetInput()
    {
        var input = File.ReadAllLines("Inputs/06.txt");

        var inputJagged = new string[input.Length][];
        foreach (var line in input.WithIndex())
        {
            inputJagged[line.Index] = line.Item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        return inputJagged;
    }

    public override ValueTask<string> Solve_1()
    {
        var inputRaw = GetInput();
        var input = inputRaw[0]
            .Select((_, colIdx) => inputRaw.Select(row => row[colIdx]).ToArray())
            .ToArray();

        ulong totalAnswer = 0;

        foreach (var row in input)
        {
            var operand = row.Last();

            var rowTotal = operand == "*" ? 1UL : 0UL;

            foreach (var num in row.SkipLast(1))
            {
                var numAsUlong = ulong.Parse(num);

                if (operand == "*")
                {
                    rowTotal *= numAsUlong;
                }
                else
                {
                    rowTotal += numAsUlong;
                }
            }

            totalAnswer += rowTotal;
        }

        return new ValueTask<string>(totalAnswer.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        throw new NotImplementedException();
    }
}