namespace AdventOfCode;

public class Day02 : BaseDay
{
    private string[] _inputs = File.ReadAllText("Inputs/02.txt").Split(",");

    private static long CountDigit(long n)
    {
        return (long)Math.Floor(Math.Log10(n) + 1);
    }

    public override ValueTask<string> Solve_1()
    {
        long totalInvalid = 0;

        foreach (var range in _inputs)
        {
            var ranges = range.Split("-");
            var min = long.Parse(ranges[0]);
            var max = long.Parse(ranges[1]);

            for (var i = min; i <= max; i++)
            {
                // No leading zeros but "just in case"
                if (i == 0) continue;

                var numDigits = CountDigit(i);

                if (numDigits % 2 != 0) continue;

                // Convert to string
                var iAsStr = i.ToString();

                var firstHalf = numDigits > 2 ? iAsStr[..(int)(numDigits / 2)] : iAsStr[..1];
                var secondHalf = iAsStr[(int)(numDigits / 2)..];

                // Compare two ranges
                if (string.Equals(firstHalf, secondHalf))
                {
                    totalInvalid += i;
                }
            }
        }

        return new ValueTask<string>(totalInvalid.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        throw new NotImplementedException();
    }
}