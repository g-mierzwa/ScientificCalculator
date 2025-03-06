namespace ScientificCalculator.Tokenizer;

public class CosineFunctionToken : FunctionToken
{
    public CosineFunctionToken()
    {
        TextRepresentation = "cos";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double input)
    {
        return Math.Cos(input);
    }
}
