namespace ScientificCalculator.Tokenizer;

public class UnaryMinusOperatorToken : UnaryOperatorToken
{
    public UnaryMinusOperatorToken()
    {
        TextRepresentation = "u-";
    }
    
    public override double Calculate(double operand)
    {
        return -operand;
    }
}
