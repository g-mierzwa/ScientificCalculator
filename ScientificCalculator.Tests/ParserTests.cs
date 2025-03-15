using ScientificCalculator.Parser;
using ScientificCalculator.Tokenizer;

namespace ScientificCalculator.Tests;

[TestFixture]
public class ParserTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCaseSource(nameof(CorrectInputCases))]
    public void CorrectInputTest(Queue<Token> input, Queue<Token> expected)
    {
        var actual = ShuntingYardParser.Parse(input);
        Assert.That(actual, Is.EqualTo(expected).AsCollection);
    }

    [Test]
    public void MismatchedParenthesesTest()
    {
        var input = TokenizerMain.Tokenize("2 * (5 - 8)) + (-3 * 2)");
        Assert.That(() => ShuntingYardParser.Parse(input), Throws.Exception.TypeOf<ArgumentException>());
    }

    [Test]
    public void NullInputTest()
    {
        Queue<Token>? input = null;
        Assert.That(() => ShuntingYardParser.Parse(input), Throws.Exception.TypeOf<ArgumentNullException>());
    }

    private static readonly object[] CorrectInputCases =
    [
        // 4 + 7 * 2 - 1 => 4 7 2 * + 1 -
        new object[] { new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new AdditionOperatorToken(),
                            new NumberToken(7.0),
                            new MultiplicationOperatorToken(),
                            new NumberToken(2.0),
                            new SubstractionOperatorToken(),
                            new NumberToken(1.0)
                        ]),
                        new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new NumberToken(7.0),
                            new NumberToken(2.0),
                            new MultiplicationOperatorToken(),
                            new AdditionOperatorToken(),
                            new NumberToken(1.0),
                            new SubstractionOperatorToken()
                        ]) },
        // (4,298 + 7,506) * (2,12121212 - 1,67) => 4,298 7,506 + 2,12121212 1,67 - *
        new object[] { new Queue<Token>(
                        [
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
                        ]),
                        new Queue<Token>(
                        [
                            new NumberToken(4.298),
                            new NumberToken(7.506),
                            new AdditionOperatorToken(),
                            new NumberToken(2.12121212),
                            new NumberToken(1.67),
                            new SubstractionOperatorToken(),
                            new MultiplicationOperatorToken()
                        ]) },
        // -4 + sin(25 * +4,3) - cos(tan(-45)) => 4 u- 25 4,3 u+ * sin + 45 u- tan cos -
        new object[] { new Queue<Token>(
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
                        ]),
                        new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new UnaryMinusOperatorToken(),
                            new NumberToken(25.0),
                            new NumberToken(4.3),
                            new UnaryPlusOperatorToken(),
                            new MultiplicationOperatorToken(),
                            new SineFunctionToken(),
                            new AdditionOperatorToken(),
                            new NumberToken(45.0),
                            new UnaryMinusOperatorToken(),
                            new TangentFunctionToken(),
                            new CosineFunctionToken(),
                            new SubstractionOperatorToken()
                        ]) },
        // 4 + 7 * sin 2 - 1 => 4 7 2 sin * + 1 -
        new object[] { new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new AdditionOperatorToken(),
                            new NumberToken(7.0),
                            new MultiplicationOperatorToken(),
                            new SineFunctionToken(),
                            new NumberToken(2.0),
                            new SubstractionOperatorToken(),
                            new NumberToken(1.0)
                        ]),
                        new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new NumberToken(7.0),
                            new NumberToken(2.0),
                            new SineFunctionToken(),
                            new MultiplicationOperatorToken(),
                            new AdditionOperatorToken(),
                            new NumberToken(1.0),
                            new SubstractionOperatorToken()
                        ]) }
    ];
}
