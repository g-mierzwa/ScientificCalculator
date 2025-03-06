namespace ScientificCalculator.Tokenizer;

public abstract class BinaryOperatorToken : OperatorToken
{
    public abstract double Calculate(double operand1, double operand2);
}
