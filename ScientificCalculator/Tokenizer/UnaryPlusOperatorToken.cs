namespace ScientificCalculator.Tokenizer;

public class UnaryPlusOperatorToken : UnaryOperatorToken
{
    public UnaryPlusOperatorToken()
    {
        TextRepresentation = "u+";
        Precedence = 3;
    }
    
    public override NumberToken Calculate(NumberToken operand)
    {
        return new NumberToken(operand.Value);
    }
}
