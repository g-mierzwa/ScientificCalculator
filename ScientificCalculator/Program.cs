using ScientificCalculator.Tokenizer;
using ScientificCalculator.Parser;
using ScientificCalculator.Evaluator;

string expression = "2 ^ 3 / 2 ^ 2";
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

Console.WriteLine($"Final Value = {RpnEvaluator.Evaluate(rpn)}");
