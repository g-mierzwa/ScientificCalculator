using ScientificCalculator.Tokenizer;

string expression = "(4 + 7) * (12,6-9,7^2 + 5/3asd - sin (-45))";
var tokens = Tokenizer.Tokenize(expression);

Console.WriteLine(expression);
if (tokens is not null)
{
    foreach (var token in tokens)
    {
        Console.WriteLine(token);
    }
}
