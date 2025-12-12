namespace AdventOfCode;

public class Day04 : BaseDay
{
    private string[] _inputs = File.ReadAllLines("Inputs/04.txt");

    private List<string> PadInputs(string[] inputs)
    {
        var inputsList = inputs.ToList();

        for (var i = 0; i < inputsList.Count; i++)
        {
            inputsList[i] = '.' + inputsList[i] + '.';
        }

        var topBottom = new string('.', inputsList[0].Length);
        inputsList.Insert(0, topBottom);
        inputsList.Add(topBottom);

        return inputsList;
    }

    // private byte FilledCell(int row, int col, List<string> grid, char filledSymbol = '@')
    // {
    //     return grid[row][col] == filledSymbol ? (byte)1 : (byte)0;
    // }

    private byte FilledCell(int row, int col, char[][] grid, char filledSymbol = '@')
    {
        return grid[row][col] == filledSymbol ? (byte)1 : (byte)0;
    }

    private T[][] CopyArray<T>(T[][] source)
    {
        return source.Select(s => s.ToArray()).ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        var inputs = PadInputs(_inputs).Select(i => i.ToCharArray()).ToArray();

        var totalAccessible = 0;

        for (var row = 1; row < inputs.Length - 1; row++)
        {
            for (var col = 1; col < inputs[row].Length - 1; col++)
            {
                if (inputs[row][col] != '@') continue;

                byte numOccupied = 0;

                // Up
                numOccupied += FilledCell(row - 1, col, inputs);

                // Down
                numOccupied += FilledCell(row + 1, col, inputs);

                // Left
                numOccupied += FilledCell(row, col - 1, inputs);

                // Right
                numOccupied += FilledCell(row, col + 1, inputs);

                // UpRight
                numOccupied += FilledCell(row - 1, col + 1, inputs);

                // UpLeft
                numOccupied += FilledCell(row - 1, col - 1, inputs);

                // DownRight
                numOccupied += FilledCell(row + 1, col + 1, inputs);

                // DownLeft
                numOccupied += FilledCell(row + 1, col - 1, inputs);

                if (numOccupied < 4) totalAccessible++;
            }
        }

        return new ValueTask<string>(totalAccessible.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var inputs = PadInputs(_inputs).Select(i => i.ToCharArray()).ToArray();
        var inputsCopy = CopyArray(inputs);

        var previousTotalAccessible = -1;
        var totalAccessible = 0;

        while (totalAccessible != previousTotalAccessible)
        {
            previousTotalAccessible = totalAccessible;
            
            for (var row = 1; row < inputs.Length - 1; row++)
            {
                for (var col = 1; col < inputs[row].Length - 1; col++)
                {
                    if (inputs[row][col] != '@') continue;

                    byte numOccupied = 0;

                    // Up
                    numOccupied += FilledCell(row - 1, col, inputs);

                    // Down
                    numOccupied += FilledCell(row + 1, col, inputs);

                    // Left
                    numOccupied += FilledCell(row, col - 1, inputs);

                    // Right
                    numOccupied += FilledCell(row, col + 1, inputs);

                    // UpRight
                    numOccupied += FilledCell(row - 1, col + 1, inputs);

                    // UpLeft
                    numOccupied += FilledCell(row - 1, col - 1, inputs);

                    // DownRight
                    numOccupied += FilledCell(row + 1, col + 1, inputs);

                    // DownLeft
                    numOccupied += FilledCell(row + 1, col - 1, inputs);

                    if (numOccupied >= 4) continue;
                    
                    totalAccessible++;
                    inputsCopy[row][col] = '.';
                }
            }
            
            inputs = CopyArray(inputsCopy);
        }

        return new ValueTask<string>(totalAccessible.ToString());
    }
}