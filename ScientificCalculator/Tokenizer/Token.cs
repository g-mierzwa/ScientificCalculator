namespace ScientificCalculator.Tokenizer;

public abstract class Token
{
    public  string TextRepresentation { get; set; } = String.Empty;
    public override string ToString()
    {
        return TextRepresentation;
    } 
}
