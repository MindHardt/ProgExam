namespace ProgExam;

internal class Program
{
    static void Main(string[] args)
    {
        string[] contents = File.ReadAllLines("path.txt");

        RobotPath path = RobotPath.FromFile(contents);
        Console.WriteLine(string.Join('\n', path.Path));

        Console.ReadKey(false);
        ShowMoves(path);

        Console.WriteLine($"Финальная точка: {path.DestinationCoords}");
        Console.WriteLine($"Искомая точка: {path.FinalCoords}");
        Console.WriteLine(path.HasReachedDestination);
    }

    static void ShowMoves(RobotPath path)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (MoveDelta coords in path.Path) 
        {
            Console.Clear();
            Console.SetCursorPosition(coords.X, coords.Y);
            Console.Write('+');

            Console.ReadKey(false);
        }
        Console.ResetColor();
        Console.Clear();
    }
}