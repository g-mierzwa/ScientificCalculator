namespace ScientificCalculator.Tokenizer;

public class DivisionOperatorToken : BinaryOperatorToken
{
    public DivisionOperatorToken()
    {
        TextRepresentation = "/";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        ArgumentOutOfRangeException.ThrowIfZero(operand2);
        return operand1 / operand2;
    }
}
