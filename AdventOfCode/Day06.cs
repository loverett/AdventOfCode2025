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

        var totalAnswer = 0UL;

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
        var inputRaw = File.ReadAllLines("Inputs/06.txt");
        var input = new char[inputRaw.Length][];
        foreach (var line in inputRaw.WithIndex())
        {
            input[line.Index] = line.Item.ToCharArray();
        }

        var totalAnswer = 0UL;
        var colNum = new List<char>();
        var colTotal = 0UL;
        var operand = ' ';

        for (var col = 0; col < input[0].Length; col++)
        {
            colNum.Clear();

            // Find operand
            if (operand == ' ')
            {
                operand = input[^1][col];

                colTotal = operand == '*' ? 1UL : 0UL;
            }

            for (var row = 0; row < input.Length - 1; row++)
            {
                if (input[row][col] == ' ') continue;
                colNum.Add(input[row][col]);
            }
            
            if (!ulong.TryParse(new string(colNum.ToArray()), out var num))
            {
                totalAnswer += colTotal;
                operand = ' ';

                continue;
            }

            if (operand == '*')
            {
                colTotal *= num;
            }
            else
            {
                colTotal += num;
            }
        }

        totalAnswer += colTotal;

        return new ValueTask<string>(totalAnswer.ToString());
    }
}