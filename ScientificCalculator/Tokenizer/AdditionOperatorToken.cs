namespace ScientificCalculator.Tokenizer;

public class AdditionOperatorToken : BinaryOperatorToken
{
    public AdditionOperatorToken()
    {
        TextRepresentation = "+";
        Precedence = 1;
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        return operand1 + operand2;
    }
}
