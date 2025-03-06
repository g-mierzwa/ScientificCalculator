namespace ScientificCalculator.Tokenizer;

public abstract class BinaryOperatorToken : OperatorToken
{
    public int Precedence { get; set; }
    public abstract double Calculate(double operand1, double operand2);
}
