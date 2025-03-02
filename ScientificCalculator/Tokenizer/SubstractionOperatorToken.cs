namespace ScientificCalculator.Tokenizer;

public class SubstractionOperatorToken : BinaryOperatorToken
{
    public SubstractionOperatorToken()
    {
        TextRepresentation = "-";
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        return operand1 - operand2;
    }
}
