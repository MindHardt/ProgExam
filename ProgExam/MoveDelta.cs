using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace ProgExam;

internal readonly record struct MoveDelta :
    IAdditionOperators<MoveDelta, MoveDelta, MoveDelta>,
    IMultiplyOperators<MoveDelta, int, MoveDelta>,
    IParsable<MoveDelta>,
    IEquatable<MoveDelta>
{
    public int X { get; }
    public int Y { get; }

    public MoveDelta(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static implicit operator MoveDelta((int x, int y) tuple)
        => new(tuple.x, tuple.y);

    public static MoveDelta operator *(MoveDelta delta, int quantifier)
        => new(delta.X * quantifier, delta.Y * quantifier);

    public static MoveDelta operator +(MoveDelta left, MoveDelta right)
        => new(left.X + right.X, left.Y + right.Y);

    public static MoveDelta Parse(string s, IFormatProvider? provider = null)
    {
        string[] parts = s.Split(';');
        if (parts.Length is not 2) throw new FormatException("Input string was not in correct format.");

        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);

        return (x, y);
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MoveDelta result)
    {
        result = default;
        if (s is null) return false;

        string[] parts = s.Split(';');
        if (parts.Length is not 2) return false;

        if (int.TryParse(parts[0], out int x) is false ||
            int.TryParse(parts[1], out int y) is false) return false;

        result = (x, y);
        return true;
    }

    public bool Equals(MoveDelta other)
        => X == other.X && Y == other.Y;

    public override int GetHashCode()
        => HashCode.Combine(X, Y);

    public override string ToString()
        => $"{X};{Y}";
}
