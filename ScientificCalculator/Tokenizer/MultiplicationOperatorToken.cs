namespace ScientificCalculator.Tokenizer;

public class MultiplicationOperatorToken : BinaryOperatorToken
{
    public MultiplicationOperatorToken()
    {
        TextRepresentation = "*";
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        return operand1 * operand2;
    }
}
