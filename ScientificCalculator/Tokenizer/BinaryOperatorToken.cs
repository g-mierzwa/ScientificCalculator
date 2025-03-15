namespace ScientificCalculator.Tokenizer;

public abstract class BinaryOperatorToken : OperatorToken
{
    public abstract NumberToken Calculate(NumberToken operand1, NumberToken operand2);
}
