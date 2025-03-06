namespace ScientificCalculator.Tokenizer;

public abstract class Token : IEquatable<Token>
{
    public string TextRepresentation { get; set; } = String.Empty;

    public bool Equals(Token? other)
    {
        if (other is null) return false;
        return TextRepresentation.Equals(other.TextRepresentation);
    }

    public override string ToString()
    {
        return TextRepresentation;
    }

    public override bool Equals(object? obj)
    {
        return obj is Token t && Equals(t);
    }

    public override int GetHashCode()
    {
        return TextRepresentation.GetHashCode();
    }
}
