namespace AdventOfCode;

public class Day05 : BaseDay
{
    private (List<(ulong Min, ulong Max)> IdRanges, List<ulong> Ids) GetInputs()
    {
        var idRanges = new List<(ulong Min, ulong Max)>();
        var ids = new List<ulong>();

        var inputs = File.ReadAllLines("Inputs/05.txt");
        foreach (var line in inputs)
        {
            if (line.Contains('-'))
            {
                var split = line.Split('-');
                var min = ulong.Parse(split[0]);
                var max = ulong.Parse(split[1]);

                idRanges.Add((min, max));
                continue;
            }

            if (ulong.TryParse(line, out var id))
            {
                ids.Add(id);
            }
        }

        return (idRanges, ids);
    }

    public override ValueTask<string> Solve_1()
    {
        var inputs = GetInputs();

        var freshIngredients =
            inputs.Ids.Count(id => inputs.IdRanges.Any(bounds => id >= bounds.Min && id <= bounds.Max));

        return new ValueTask<string>(freshIngredients.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var (idRanges, _) = GetInputs();

        var freshIngredients = 0UL;

        var orderedRanges = idRanges
            .Distinct()
            .OrderBy(i => i.Min)
            .ThenBy(i => i.Max)
            .ToList();

        var currentMin = orderedRanges[0].Min;
        var currentMax = orderedRanges[0].Max;

        foreach (var range in orderedRanges.Skip(1))
        {
            if (range.Max <= currentMax) continue;

            if (range.Min > currentMax + 1)
            {
                freshIngredients += currentMax - currentMin + 1;

                currentMin = range.Min;
            }

            currentMax = range.Max;
        }

        freshIngredients += currentMax - currentMin + 1;

        return new ValueTask<string>(freshIngredients.ToString());
    }
}