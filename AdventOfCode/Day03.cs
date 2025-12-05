namespace AdventOfCode;

public class Day03 : BaseDay
{
    private string[] _inputs = File.ReadAllLines("Inputs/03.txt");

    public override ValueTask<string> Solve_1()
    {
        var totalMaxJoltage = 0;

        foreach (var input in _inputs)
        {
            var firstBattery = input[0];
            var secondBattery = input[1];

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] > secondBattery) secondBattery = input[i];

                if (input[i] <= firstBattery || i == input.Length - 1) continue;

                firstBattery = input[i];
                secondBattery = input[i + 1];
            }

            totalMaxJoltage += int.Parse(new ReadOnlySpan<char>([firstBattery, secondBattery]));
        }


        return new ValueTask<string>(totalMaxJoltage.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        ulong totalMaxJoltage = 0;

        foreach (var input in _inputs)
        {

            var batteriesFound = 0;
            char[] joltage = { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0'};
            var lastIndex = -1;

            while (batteriesFound < 12)
            {
                for (var i = lastIndex + 1; i < input.Length - 11 + batteriesFound; i++)
                {
                    if (input[i] <= joltage[batteriesFound]) continue;
                    
                    joltage[batteriesFound] = input[i];
                    lastIndex = i;
                }

                batteriesFound++;
            }
            
            totalMaxJoltage += ulong.Parse(joltage);
        }

        return new ValueTask<string>(totalMaxJoltage.ToString());
    }
}