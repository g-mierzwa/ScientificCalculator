namespace ScientificCalculator.Tokenizer;

public class SineFunctionToken : FunctionToken
{
    public SineFunctionToken()
    {
        TextRepresentation = "sin";
    }
    
    public override double Calculate(double input)
    {
        return Math.Sin(input);
    }
}
