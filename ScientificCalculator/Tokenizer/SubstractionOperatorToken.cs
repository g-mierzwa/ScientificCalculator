namespace ScientificCalculator.Tokenizer;

public class SubstractionOperatorToken : BinaryOperatorToken
{
    public SubstractionOperatorToken()
    {
        TextRepresentation = "-";
        Precedence = 1;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        return operand1 - operand2;
    }
}
