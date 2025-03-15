using ScientificCalculator.Tokenizer;

namespace ScientificCalculator.Parser;

public class ShuntingYardParser
{
    public static Queue<Token> Parse(Queue<Token>? input)
    {
        ArgumentNullException.ThrowIfNull(input);

        Queue<Token> output = new();
        Stack<Token> operators = new();

        while (input.Count > 0)
        {
            var token = input.Dequeue();

            if (token is NumberToken numberToken)
            {
                output.Enqueue(numberToken);
            }
            else if (token is FunctionToken functionToken)
            {
                operators.Push(functionToken);
            }
            else if (token is UnaryOperatorToken unaryOperatorToken)
            {
                operators.Push(unaryOperatorToken);
            }
            else if (token is LeftParenthesisToken leftParenthesisToken)
            {
                operators.Push(leftParenthesisToken);
            }
            else if (token is RightParenthesisToken rightParenthesisToken)
            {
                while (operators.Count > 0 && operators.Peek() is not LeftParenthesisToken)
                {
                    output.Enqueue(operators.Pop());
                    if (operators.Count == 0)
                    {
                        throw new ArgumentException("Mismatched parentheses");
                    }
                }
                // discard left parenthesis from the top of the stack
                operators.Pop();

                if (operators.Count > 0 && operators.Peek() is FunctionToken functionToken1)
                {
                    output.Enqueue(operators.Pop());
                }
                else if (operators.Count > 0 && operators.Peek() is UnaryOperatorToken unaryOperatorToken1)
                {
                    output.Enqueue(operators.Pop());
                }
            }
            else if (token is BinaryOperatorToken binaryOperatorToken)
            {
                while (
                    operators.Count > 0 &&
                    operators.Peek() is not LeftParenthesisToken &&
                    ((operators.Peek() is OperatorToken t && t.Precedence > binaryOperatorToken.Precedence) ||
                    (operators.Peek() is BinaryOperatorToken t1 && t1.Precedence == binaryOperatorToken.Precedence &&
                    binaryOperatorToken.Associativity == Associativity.Left))
                )
                {
                    output.Enqueue(operators.Pop());
                }
                operators.Push(binaryOperatorToken);
            }
            else
            {
                throw new ArgumentException("Unknown token");
            }
        }

        while (operators.Count > 0)
        {
            if (operators.Peek() is LeftParenthesisToken)
            {
                throw new ArgumentException("Mismatched parentheses");
            }

            output.Enqueue(operators.Pop());
        }

        return output;
    }

    public static Queue<Token> Parse(string input)
    {
        return Parse(TokenizerMain.Tokenize(input));
    }
}
