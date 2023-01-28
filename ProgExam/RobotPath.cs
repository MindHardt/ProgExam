namespace ProgExam;

internal class RobotPath
{
    public MoveDelta InitialCoords { get; }
    public MoveDelta DestinationCoords { get; }
    public bool HasReachedDestination => FinalCoords == DestinationCoords;
    public IReadOnlyList<MoveDelta> Path { get; }
    public IReadOnlyList<Move> Moves { get; }
    public MoveDelta FinalCoords { get; }

    public RobotPath(MoveDelta initialCoords, MoveDelta destinationCoords, IReadOnlyList<Move> moves)
    {
        InitialCoords = initialCoords;
        Moves = moves;
        FinalCoords = initialCoords + moves
            .Select(m => m.TotalDelta)
            .Aggregate((md1, md2) => md1 + md2);

        DestinationCoords = destinationCoords;

        List<MoveDelta> path = new() { InitialCoords };
        foreach (MoveDelta delta in moves.Select(m => m.TotalDelta))
        {
            path.Add(path.Last() + delta);
        }
        Path = path;
    }

    public static RobotPath FromFile(string[] contents)
    {
        if (contents.Length < 2) throw new FormatException("Not enough data in file!");

        MoveDelta initial = MoveDelta.Parse(contents[0]);
        MoveDelta destination = MoveDelta.Parse(contents[1]);

        Move[] moves = contents[2..]
            .Select(s => Move.Parse(s))
            .ToArray();

        return new RobotPath(initial, destination, moves);
    }
}
