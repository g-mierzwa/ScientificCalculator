namespace ScientificCalculator.Tokenizer;

public class TangentFunctionToken : FunctionToken
{
    public TangentFunctionToken()
    {
        TextRepresentation = "tan";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double input)
    {
        return Math.Tan(input);
    }
}
