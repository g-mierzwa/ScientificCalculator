using NUnit.Framework.Legacy;
using ScientificCalculator.Tokenizer;

namespace ScientificCalculator.Tests;

[TestFixture]
public class TokenizerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(ExpressionCases))]
    public void ExpressionTest(string input, List<Token> expected)
    {
        var actual = Tokenizer.Tokenizer.Tokenize(input);
        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    private static readonly object[] ExpressionCases =
    [
        new object[] { "4 + 7 * 2 - 1", new List<Token>()
                                    {
                                        new NumberToken(4.0),
                                        new AdditionOperatorToken(),
                                        new NumberToken(7.0),
                                        new MultiplicationOperatorToken(),
                                        new NumberToken(2.0),
                                        new SubstractionOperatorToken(),
                                        new NumberToken(1.0)
                                    } },
        new object[] { "(4,298 + 7,506) * (2,12121212 - 1,67)", new List<Token>()
                                    {
                                        new LeftParenthesisToken(),
                                        new NumberToken(4.298),
                                        new AdditionOperatorToken(),
                                        new NumberToken(7.506),
                                        new RightParenthesisToken(),
                                        new MultiplicationOperatorToken(),
                                        new LeftParenthesisToken(),
                                        new NumberToken(2.12121212),
                                        new SubstractionOperatorToken(),
                                        new NumberToken(1.67),
                                        new RightParenthesisToken()
                                    } }
    ];
}
