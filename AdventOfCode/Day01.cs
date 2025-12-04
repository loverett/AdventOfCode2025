namespace AdventOfCode;

public class Day01 : BaseDay
{
    public override ValueTask<string> Solve_1()
    {
        var inputs = File.ReadAllText("Inputs/01.txt").Split("\n");

        var dialValue = 50; // Initial condition
        var zeroCount = 0;

        foreach (var input in inputs)
        {
            var spin = int.Parse(input[1..]);

            dialValue += input[0] == 'R' ? spin : -spin;

            if (dialValue % 100 == 0)
            {
                zeroCount++;
            }
        }

        return new ValueTask<string>(zeroCount.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var inputs = File.ReadAllText("Inputs/01.txt").Split("\n");

        var dialValue = 50;
        var zeroCount = 0;

        foreach (var input in inputs)
        {
            var spin = int.Parse(input[1..]);

            // Hacky...
            for (var i = 1; i <= spin; i++)
            {
                if (input[0] == 'R')
                {
                    dialValue = (dialValue - 1) % 100;
                }
                else
                {
                    dialValue = (dialValue + 1) % 100;
                }

                if (dialValue == 0)
                {
                    zeroCount++;
                }
            }
        }

        return new ValueTask<string>(zeroCount.ToString());
    }
}