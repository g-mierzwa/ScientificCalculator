namespace ScientificCalculator.Tokenizer;

public class SineFunctionToken : FunctionToken
{
    public SineFunctionToken()
    {
        TextRepresentation = "sin";
        Precedence = 3;
    }
    
    public override NumberToken Calculate(NumberToken input)
    {
        return new NumberToken(Math.Sin(input.Value));
    }
}
