namespace ScientificCalculator.Tokenizer;

public class SineFunctionToken : FunctionToken
{
    public SineFunctionToken()
    {
        TextRepresentation = "sin";
        Precedence = 2;
        Associativity = Associativity.Left;
    }
    
    public override double Calculate(double input)
    {
        return Math.Sin(input);
    }
}
