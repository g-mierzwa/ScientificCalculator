namespace ScientificCalculator.Tokenizer;

public abstract class FunctionToken : OperatorToken
{
    public abstract NumberToken Calculate(NumberToken input);
}
