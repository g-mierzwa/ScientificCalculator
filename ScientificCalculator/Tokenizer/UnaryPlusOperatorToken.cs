namespace ScientificCalculator.Tokenizer;

public class UnaryPlusOperatorToken : UnaryOperatorToken
{
    public UnaryPlusOperatorToken()
    {
        TextRepresentation = "u+";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double operand)
    {
        return operand;
    }
}
