using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day02 : BaseDay
{
    private string[] _inputs = File.ReadAllText("Inputs/02.txt").Split(",");

    public override ValueTask<string> Solve_1()
    {
        ulong totalInvalid = 0;

        foreach (var range in _inputs)
        {
            var ranges = range.Split("-");
            var min = ulong.Parse(ranges[0]);
            var max = ulong.Parse(ranges[1]);

            for (var i = min; i <= max; i++)
            {
                var iAsStr = i.ToString();
                var numDigits = iAsStr.Length;

                if (numDigits % 2 != 0) continue;

                var firstHalf = iAsStr[..(numDigits / 2)];
                var secondHalf = iAsStr[(numDigits / 2)..];

                // Compare two ranges
                if (!string.Equals(firstHalf, secondHalf)) continue;
                
                totalInvalid += i;
            }
        }

        return new ValueTask<string>(totalInvalid.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        ulong totalInvalid = 0;

        foreach (var range in _inputs)
        {
            var ranges = range.Split("-");
            var min = ulong.Parse(ranges[0]);
            var max = ulong.Parse(ranges[1]);

            for (var i = min; i <= max; i++)
            {
                var iAsStr = i.ToString();
                var numDigits = iAsStr.Length;

                var subDigits = iAsStr[..(numDigits / 2)];

                for (var j = (numDigits / 2) - 1; j >= 0; j--)
                {
                    var matchesCount = Regex.Matches(iAsStr, subDigits);

                    if (matchesCount.Count * subDigits.Length == iAsStr.Length)
                    {
                        totalInvalid += i;
                        break;
                    }

                    subDigits = subDigits[..^1];
                }
            }
        }

        return new ValueTask<string>(totalInvalid.ToString());
    }
}