using ScientificCalculator.Tokenizer;

namespace ScientificCalculator.Tests;

[TestFixture]
public class TokenizerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(CorrectExpressionCases))]
    public void CorrectExpressionTest(string input, List<Token> expected)
    {
        var actual = TokenizerMain.Tokenize(input);
        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    [TestCase("4 + 7 * sinus(2) - 1")]
    [TestCase("4 + 7,3,2 * 2 - 1")]
    public void IncorrectExpressionTest(string input)
    {
        var actual = TokenizerMain.Tokenize(input);
        Assert.That(actual, Is.Null);
    }

    private static readonly object[] CorrectExpressionCases =
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
                                    } },
        new object[] { "-4 + sin(25 * +4,3) - cos(tan(-45))", new List<Token>()
                                    {
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
                                    } },
        new object[] { "   4+            7     *sin 2\t-\n1   ", new List<Token>()
                                    {
                                        new NumberToken(4.0),
                                        new AdditionOperatorToken(),
                                        new NumberToken(7.0),
                                        new MultiplicationOperatorToken(),
                                        new SineFunctionToken(),
                                        new NumberToken(2.0),
                                        new SubstractionOperatorToken(),
                                        new NumberToken(1.0)
                                    } }
    ];
}
