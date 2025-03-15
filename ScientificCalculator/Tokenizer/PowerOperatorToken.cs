namespace ScientificCalculator.Tokenizer;

public class PowerOperatorToken : BinaryOperatorToken
{
    public PowerOperatorToken()
    {
        TextRepresentation = "^";
        Precedence = 4;
        Associativity = Associativity.Right;
    }
    
    public override NumberToken Calculate(NumberToken operand1, NumberToken operand2)
    {
        return new NumberToken(Math.Pow(operand1.Value, operand2.Value));
    }
}
