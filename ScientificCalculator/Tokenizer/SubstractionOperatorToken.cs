namespace ScientificCalculator.Tokenizer;

public class SubstractionOperatorToken : BinaryOperatorToken
{
    public SubstractionOperatorToken()
    {
        TextRepresentation = "-";
        Precedence = 1;
        Associativity = Associativity.Left;
    }
    
    public override NumberToken Calculate(NumberToken operand1, NumberToken operand2)
    {
        return new NumberToken(operand1.Value - operand2.Value);
    }
}
