namespace ScientificCalculator.Tokenizer;

public abstract class UnaryOperatorToken : OperatorToken
{
    public abstract double Calculate(double operand);
}
