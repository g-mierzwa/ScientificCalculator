namespace ScientificCalculator.Tokenizer;

public class NumberToken : Token
{
    public NumberToken(double value)
    {
        Value = value;
    }
    public double Value { get; set; }
    public override string ToString()
    {
        return Value.ToString();
    }
}
