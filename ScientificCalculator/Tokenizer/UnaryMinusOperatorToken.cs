namespace ScientificCalculator.Tokenizer;

public class UnaryMinusOperatorToken : UnaryOperatorToken
{
    public UnaryMinusOperatorToken()
    {
        TextRepresentation = "u-";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double operand)
    {
        return -operand;
    }
}
