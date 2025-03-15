using ScientificCalculator.Tokenizer;

namespace ScientificCalculator.Evaluator;

public class RpnEvaluator
{
    public static double Evaluate(Queue<Token>? input)
    {
        ArgumentNullException.ThrowIfNull(input);

        Stack<Token> stack = new();

        while (input.Count > 0)
        {
            var token = input.Dequeue();

            if (token is NumberToken numberToken)
            {
                stack.Push(numberToken);
            }
            else if (token is FunctionToken functionToken)
            {
                var operand = (NumberToken)stack.Pop();
                var calculatedValue = functionToken.Calculate(operand);
                stack.Push(calculatedValue);
            }
            else if (token is UnaryOperatorToken unaryOperatorToken)
            {
                var operand = (NumberToken)stack.Pop();
                var calculatedValue = unaryOperatorToken.Calculate(operand);
                stack.Push(calculatedValue);
            }
            else if (token is BinaryOperatorToken binaryOperatorToken)
            {
                var operand2 = (NumberToken)stack.Pop();
                var operand1 = (NumberToken)stack.Pop();
                var calculatedValue = binaryOperatorToken.Calculate(operand1, operand2);
                stack.Push(calculatedValue);
            }
        }

        var finalValue = (NumberToken)stack.Pop();
        return finalValue.Value;
    }
}
