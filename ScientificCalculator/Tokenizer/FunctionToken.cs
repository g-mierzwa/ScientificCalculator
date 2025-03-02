namespace ScientificCalculator.Tokenizer;

public abstract class FunctionToken : Token
{
    public abstract double Calculate(double input);
}
