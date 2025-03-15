namespace ScientificCalculator.Tokenizer;

public class DivisionOperatorToken : BinaryOperatorToken
{
    public DivisionOperatorToken()
    {
        TextRepresentation = "/";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override NumberToken Calculate(NumberToken operand1, NumberToken operand2)
    {
        return new NumberToken(operand1.Value / operand2.Value);
    }
}
