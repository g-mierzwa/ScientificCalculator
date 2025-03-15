namespace ScientificCalculator.Tokenizer;

public class CosineFunctionToken : FunctionToken
{
    public CosineFunctionToken()
    {
        TextRepresentation = "cos";
        Precedence = 3;
    }
    
    public override NumberToken Calculate(NumberToken input)
    {
        return new NumberToken(Math.Cos(input.Value));
    }
}
