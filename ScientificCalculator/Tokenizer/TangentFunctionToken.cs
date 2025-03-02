namespace ScientificCalculator.Tokenizer;

public class TangentFunctionToken : FunctionToken
{
    public TangentFunctionToken()
    {
        TextRepresentation = "tan";
    }
    
    public override double Calculate(double input)
    {
        return Math.Tan(input);
    }
}
