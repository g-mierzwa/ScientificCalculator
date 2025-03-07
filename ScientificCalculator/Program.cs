using ScientificCalculator.Tokenizer;
using ScientificCalculator.Parser;

string expression = "-4 + sin(25 * +4,3) - cos(tan(-45))";
var tokens = TokenizerMain.Tokenize(expression);

Console.WriteLine(expression);
if (tokens is not null)
{
    foreach (var token in tokens)
    {
        Console.WriteLine(token);
    }
}

var rpn = ShuntingYardParser.Parse(tokens);

Console.WriteLine(expression);
if (rpn is not null)
{
    foreach (var token in rpn)
    {
        Console.WriteLine(token);
    }
}


Console.WriteLine("-----------------------------------------");
var aaa = new Queue<Token>(
                                    [
                                        new UnaryMinusOperatorToken(),
                                        new NumberToken(4.0),
                                        new AdditionOperatorToken(),
                                        new SineFunctionToken(),
                                        new LeftParenthesisToken(),
                                        new NumberToken(25.0),
                                        new MultiplicationOperatorToken(),
                                        new UnaryPlusOperatorToken(),
                                        new NumberToken(4.3),
                                        new RightParenthesisToken(),
                                        new SubstractionOperatorToken(),
                                        new CosineFunctionToken(),
                                        new LeftParenthesisToken(),
                                        new TangentFunctionToken(),
                                        new LeftParenthesisToken(),
                                        new UnaryMinusOperatorToken(),
                                        new NumberToken(45.0),
                                        new RightParenthesisToken(),
                                        new RightParenthesisToken()
                                    ]);
foreach (var token in aaa)
{
    Console.WriteLine(token);
}