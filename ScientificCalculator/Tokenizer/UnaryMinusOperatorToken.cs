namespace ScientificCalculator.Tokenizer;

public class UnaryMinusOperatorToken : UnaryOperatorToken
{
    public UnaryMinusOperatorToken()
    {
        TextRepresentation = "u-";
        Precedence = 3;
    }
    
    public override NumberToken Calculate(NumberToken operand)
    {
        return new NumberToken(-operand.Value);
    }
}
