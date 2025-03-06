using ScientificCalculator.Tokenizer;
using ScientificCalculator.Parser;

string expression = "sin ( cos ( 2,3 ) / 3 * 0,999 )";
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
