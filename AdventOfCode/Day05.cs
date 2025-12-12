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
                var min = ulong.Parse(line.Split('-')[0]);
                var max = ulong.Parse(line.Split('-')[1]);

                idRanges.Add((min, max));
            }

            if (ulong.TryParse(line, out ulong id))
            {
                ids.Add(id);
            }
        }

        return (idRanges, ids);
    }

    public override ValueTask<string> Solve_1()
    {
        var inputs = GetInputs();

        var freshIngredients = inputs.Ids.Count(id => inputs.IdRanges.Any(bounds => id >= bounds.Min && id <= bounds.Max));
        
        return new ValueTask<string>(freshIngredients.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var (idRanges, _) = GetInputs();
        
        // Worth a try but gives 'System.OutOfMemoryException'
        // var freshIngredientIds = new HashSet<ulong>();
        //
        // foreach (var valueTuple in idRanges)
        // {
        //     for (var i = valueTuple.Min; i <= valueTuple.Max; i++)
        //     {
        //         freshIngredientIds.Add(i);
        //     }
        // }
        //   
        // return new ValueTask<string>(freshIngredientIds.Count.ToString());
    }
}