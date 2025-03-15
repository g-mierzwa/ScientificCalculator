namespace ScientificCalculator.Tokenizer;

public abstract class UnaryOperatorToken : OperatorToken
{
    public abstract NumberToken Calculate(NumberToken operand);
}
