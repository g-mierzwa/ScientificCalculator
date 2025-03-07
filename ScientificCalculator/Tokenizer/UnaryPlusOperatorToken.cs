namespace ScientificCalculator.Tokenizer;

public class UnaryPlusOperatorToken : UnaryOperatorToken
{
    public UnaryPlusOperatorToken()
    {
        TextRepresentation = "u+";
    }
    
    public override double Calculate(double operand)
    {
        return operand;
    }
}
