namespace ScientificCalculator.Tokenizer;

public class MultiplicationOperatorToken : BinaryOperatorToken
{
    public MultiplicationOperatorToken()
    {
        TextRepresentation = "*";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double operand1, double operand2)
    {
        return operand1 * operand2;
    }
}
