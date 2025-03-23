using ScientificCalculator.Tokenizer;
using ScientificCalculator.Parser;
using ScientificCalculator.Evaluator;

Console.WriteLine("Enter a mathematical expression to evaluate (or press ENTER to use one of the defaults):");
string? expression = Console.ReadLine();
if (string.IsNullOrWhiteSpace(expression))
{
    expression = GetRandomExpression();
    Console.WriteLine("Expression:");
    Console.WriteLine(expression);
}

try
{
    var tokens = TokenizerMain.Tokenize(expression);

    Console.WriteLine("Tokens:");
    Console.Write("[");
    Console.Write(tokens is not null ? string.Join("] [", tokens) : "Tokenizer error");
    Console.WriteLine("]");

    var rpn = ShuntingYardParser.Parse(tokens);

    Console.WriteLine("Tokens in RPN:");
    Console.Write("[");
    Console.Write(rpn is not null ? string.Join("] [", rpn) : "Parser error");
    Console.WriteLine("]");

    Console.WriteLine($"Value = {RpnEvaluator.Evaluate(rpn)}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}

static string GetRandomExpression()
{
    return new Random().Next(1, 6) switch
    {
        1 => "4 + 7 * 2 - 1",
        2 => "(4,298 + 7,506) * (2,12121212 - 1,67)",
        3 => "-4 + sin(25 * +4,3) - cos(tan(-45))",
        4 => "4 + 7 * sin 2 - 1",
        _ => "2 ^ 3 / 2 ^ 2"
    };
}
