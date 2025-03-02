using System.Globalization;

namespace ScientificCalculator.Tokenizer;

public class Tokenizer
{
    public static List<Token>? Tokenize(string input)
    {
        var output = new List<Token>();
        int currentIndex = 0;
        string current = String.Empty;
        char decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator.ToCharArray()[0];

        try
        {
            while (currentIndex < input.Length)
            {
                char c = input[currentIndex];
            
                if (char.IsLetter(c))
                {
                    current += c;
                
                    if (currentIndex == input.Length - 1 || !char.IsLetter(input[currentIndex + 1]))
                    {
                        output.Add(TokenFromString(current));
                        current = String.Empty;
                    }
                }
                else if (char.IsDigit(c) || c == decimalSeparator)
                {
                    current += c;

                    if (currentIndex == input.Length - 1 || (!char.IsDigit(input[currentIndex + 1]) && input[currentIndex + 1] != decimalSeparator))
                    {
                        output.Add(TokenFromString(current));
                        current = String.Empty;
                    }
                }
                // We have to check if + or - are unary operators:
                // It happens if they are first operator in expression, appear after operator, function or left parenthesis
                else if ((c == '-' || c == '+') &&
                (output.Count == 0 || output.Last() is OperatorToken || output.Last() is FunctionToken || output.Last() is LeftParenthesisToken))
                {
                    output.Add(TokenFromString(c == '-' ? "u-" : "u+"));
                }
                else if ("+-*/^()".Contains(c))
                {
                    output.Add(TokenFromString(c.ToString()));
                }

                currentIndex++;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine (ex.Message);
            return null;
        }

        return output;
    }

    private static Token TokenFromString(string textRepresentation)
    {
        if (Double.TryParse(textRepresentation, out double result))
        {
            return new NumberToken(result);
        }
        return textRepresentation switch
        {
            "+" => new AdditionOperatorToken(),
            "-" => new SubstractionOperatorToken(),
            "*" => new MultiplicationOperatorToken(),
            "/" => new DivisionOperatorToken(),
            "^" => new PowerOperatorToken(),
            "(" => new LeftParenthesisToken(),
            ")" => new RightParenthesisToken(),
            "sin" => new SineFunctionToken(),
            "cos" => new CosineFunctionToken(),
            "tan" => new TangentFunctionToken(),
            "u-" => new UnaryMinusOperatorToken(),
            "u+" => new UnaryPlusOperatorToken(),
            _ => throw new ArgumentException("Unrecognized token"),
        };
    }
}
