namespace ScientificCalculator.Tokenizer;

public class CosineFunctionToken : FunctionToken
{
    public CosineFunctionToken()
    {
        TextRepresentation = "cos";
    }
    
    public override double Calculate(double input)
    {
        return Math.Cos(input);
    }
}
