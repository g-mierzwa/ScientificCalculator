namespace ScientificCalculator.Tokenizer;

public abstract class FunctionToken : OperatorToken
{
    public abstract double Calculate(double input);
}
