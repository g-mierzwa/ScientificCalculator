namespace ScientificCalculator.Tokenizer;

public class TangentFunctionToken : FunctionToken
{
    public TangentFunctionToken()
    {
        TextRepresentation = "tan";
        Precedence = 3;
    }
    
    public override NumberToken Calculate(NumberToken input)
    {
        return new NumberToken(Math.Tan(input.Value));
    }
}
