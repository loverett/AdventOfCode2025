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
        throw new NotImplementedException();
    }
}

// public class Day01 : BaseDay
// {
//     private static int Overflow(int val, int range)
//     {
//         return val % range;
//     }
//
//     private static int Underflow(int val, int range)
//     {
//         return (val % range + range) % range;
//     }
//
//     public override ValueTask<string> Solve_1()
//     {
//         var zeroCount = 0;
//         var dialVal = 50;
//
//         const int min = 0;
//         const int max = 99;
//
//         var input = File.ReadAllText("Inputs/01.txt").Split("\n");
//
//         foreach (var i in input)
//         {
//             _ = int.TryParse(i.AsSpan(1), out var spin);
//
//             dialVal += i[0] == 'R' ? spin : -spin;
//
//             dialVal = dialVal switch
//             {
//                 > max => Overflow(dialVal, max + 1),
//                 < min => Underflow(dialVal, max + 1),
//                 _ => dialVal
//             };
//
//             if (dialVal == 0) zeroCount++;
//         }
//
//         return new ValueTask<string>(zeroCount.ToString());
//     }
//
//     public override ValueTask<string> Solve_2()
//     {
//         var zeroCount = 0;
//         var dialVal = 50;
//
//         const int min = 0;
//         const int max = 99;
//
//         var input = File.ReadAllText("Inputs/01.txt").Split("\n");
//
//         foreach (var i in input)
//         {
//             _ = int.TryParse(i.AsSpan(1), out var spin);
//
//             dialVal += i[0] == 'R' ? spin : -spin;
//
//             
//         }
//
//         return new ValueTask<string>(zeroCount.ToString());
//     }
// }