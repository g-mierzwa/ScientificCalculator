namespace ScientificCalculator.Tokenizer;

public abstract class OperatorToken : Token
{
    public int Precedence { get; set; }
    public Associativity Associativity { get; set; }
}

public enum Associativity { Left, Right }
