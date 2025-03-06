namespace ScientificCalculator.Tokenizer;

public class PowerOperatorToken : BinaryOperatorToken
{
    public PowerOperatorToken()
    {
        TextRepresentation = "^";
        Precedence = 3;
        Associativity = Associativity.Right;
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        return Math.Pow(operand1, operand2);
    }
}
