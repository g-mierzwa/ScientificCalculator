namespace ScientificCalculator.Tokenizer;

public class DivisionOperatorToken : BinaryOperatorToken
{
    public DivisionOperatorToken()
    {
        TextRepresentation = "/";
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        ArgumentOutOfRangeException.ThrowIfZero(operand2);
        return operand1 / operand2;
    }
}
