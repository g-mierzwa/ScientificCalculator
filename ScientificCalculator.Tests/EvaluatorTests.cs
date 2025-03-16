using ScientificCalculator.Tokenizer;
using ScientificCalculator.Evaluator;

namespace ScientificCalculator.Tests;

[TestFixture]
public class EvaluatorTests
{
    private double epsilon;

    [SetUp]
    public void Setup()
    {
        epsilon = 0.000001;
    }

    [TestCaseSource(nameof(CorrectInputCases))]
    public void CorrectInputTest(Queue<Token> input, double expected)
    {
        var actual = RpnEvaluator.Evaluate(input);
        Assert.That(Math.Abs(actual - expected), Is.LessThan(epsilon));
    }

    private static readonly object[] CorrectInputCases =
    [
        // 4 + 7 * 2 - 1 => 4 7 2 * + 1 - => 17
        new object[] { new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new NumberToken(7.0),
                            new NumberToken(2.0),
                            new MultiplicationOperatorToken(),
                            new AdditionOperatorToken(),
                            new NumberToken(1.0),
                            new SubstractionOperatorToken()
                        ]), 17.0 },
        // (4,298 + 7,506) * (2,12121212 - 1,67) => 4,298 7,506 + 2,12121212 1,67 - * => 5,32610786448
        new object[] { new Queue<Token>(
                        [
                            new NumberToken(4.298),
                            new NumberToken(7.506),
                            new AdditionOperatorToken(),
                            new NumberToken(2.12121212),
                            new NumberToken(1.67),
                            new SubstractionOperatorToken(),
                            new MultiplicationOperatorToken()
                        ]), 5.32610786448 },
        // -4 + sin(25 * +4,3) - cos(tan(-45)) => 4 u- 25 4,3 u+ * sin + 45 u- tan cos - =< -3,31770984947
        new object[] { new Queue<Token>(
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
                        ]), -3.31770984947 },
        // 4 + 7 * sin 2 - 1 => 4 7 2 sin * + 1 - => 9,36508198778
        new object[] { new Queue<Token>(
                        [
                            new NumberToken(4.0),
                            new NumberToken(7.0),
                            new NumberToken(2.0),
                            new SineFunctionToken(),
                            new MultiplicationOperatorToken(),
                            new AdditionOperatorToken(),
                            new NumberToken(1.0),
                            new SubstractionOperatorToken()
                        ]), 9.36508198778 },
        // 2 ^ 3 / 2 ^ 2 => 2 3 ^ 2 2 ^ / => 2
        new object[] { new Queue<Token>(
                        [
                            new NumberToken(2.0),
                            new NumberToken(3.0),
                            new PowerOperatorToken(),
                            new NumberToken(2.0),
                            new NumberToken(2.0),
                            new PowerOperatorToken(),
                            new DivisionOperatorToken()
                        ]), 2.0 }
    ];
}
