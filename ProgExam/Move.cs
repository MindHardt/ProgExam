using System.Diagnostics.CodeAnalysis;

namespace ProgExam;

internal class Move : IParsable<Move>
{
    public MoveDelta TotalDelta { get; }
    public int Repeats { get; }
    public MoveDelta Delta { get; }

    public Move(MoveDelta delta, int repeats)
    {
        Repeats = repeats;
        Delta = delta;
        TotalDelta = delta * repeats;
    }

    public static Move Parse(string s, IFormatProvider? provider = null)
    {
        string[] parts = s.Split(' ');
        if (parts.Length is not 2) throw new FormatException("Input contains more than 1 space");

        MoveDelta? delta = ParseDelta(parts[0]);
        if (delta is null) throw new FormatException($"Move literal {parts[0]} is not defined.");

        int repeats = int.Parse(parts[1]);
        return new(delta.Value, repeats);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Move result)
    {
        result = null;
        if (s is null) return false;

        string[] parts = s.Split(' ');
        if (parts.Length is not 2) return false;

        MoveDelta? delta = ParseDelta(s);
        if (delta is null) return false;

        if (int.TryParse(parts[1], out int repeats) is false) return false;

        result = new(delta.Value, repeats);
        return true;
    }

    private static MoveDelta? ParseDelta(string s)
    {
        MoveDelta? delta = s.ToLower() switch
        {
            "r" => (1, 0),
            "u" => (0, -1),
            "l" => (-1, 0),
            "d" => (0, 1),

            "dur" => (1, -1),
            "dul" => (-1, -1),
            "ddl" => (-1, 1),
            "ddr" => (1, 1),

            _ => null,
        };
        return delta;
    }

    public static MoveDelta operator +(Move left, Move right)
        => left.TotalDelta + right.TotalDelta;

    public static MoveDelta operator +(Move move, MoveDelta delta)
        => move.TotalDelta + delta;
}
