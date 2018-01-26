using System.Collections.Generic;
using Csd.Calculator.Token.Operator;
using NUnit.Framework;

namespace Csd.Calculator.Token
{
    public class OperatorTokenTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ExecuteAdditionOperatorSymbolGoodSum()
        {
            var opToken = OperatorToken.CreateOperatorToken("+");
            var stack = new Stack<CalculatorToken>();
            stack.Push(new OperandToken("5"));
            stack.Push(new OperandToken("3"));

            Assert.AreEqual(new OperandToken("8"), opToken.Execute(stack));
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void IsValidOperatorSymbolTrueForPlus()
        {
            Assert.True(OperatorToken.IsValidOperatorSymbol("+"));
        }
        [Test]
        public void IsOperatorTrue()
        {
            var token = OperatorToken.CreateOperatorToken("+");
            Assert.True(token.IsOperator());
        }

        [Test]
        public void ToStringReturnsTokenSymbolAsString() 
        {
            var opToken = OperatorToken.CreateOperatorToken("+");
            Assert.AreEqual("+",opToken.ToString());
        }

        [Test]
        public void AdditionOperatorTokenCanAddOperandsSuccessfully() 
        {
            var opToken = OperatorToken.CreateOperatorToken("+");
            var stack = new Stack<CalculatorToken>();
            stack.Push(new OperandToken(3.5));
            stack.Push(new OperandToken(2.75));
            var expected = new OperandToken(6.25);

            Assert.AreEqual(expected, opToken.Execute(stack));
        }

        [Test]
        public void SubtractionOperatorTokenCanSubtractOperandsSuccessfully()
        {
            var opToken = OperatorToken.CreateOperatorToken("-");
            var stack = new Stack<CalculatorToken>();
            stack.Push(new OperandToken(11));
            stack.Push(new OperandToken(5));
            var expected = new OperandToken(6);

            var actual = opToken.Execute(stack);

            Assert.AreEqual(expected, actual, "OperandToken.Execute return the wrong value when subtracting ");
        }

        [Test]
        public void MultiplicationOperatorTokenCanMultiplyOperandsSuccessfully() 
        {
            var opToken = OperatorToken.CreateOperatorToken("*");
            var stack = new Stack<CalculatorToken>();
            stack.Push(new OperandToken(3.5));
            stack.Push(new OperandToken(4.0));
            var expected = new OperandToken(14.0);
        
            Assert.AreEqual(expected, opToken.Execute(stack));
        }

        [Test]
        public void CreateAdditionOperatorTokenSuccess()
        {
            const string OPERATOR_SYMBOL = "+";
            var opToken = OperatorToken.CreateOperatorToken(OPERATOR_SYMBOL);
            Assert.AreEqual(OPERATOR_SYMBOL, opToken.ToString());
        }

        [Test]
        public void CreateMultiplicationOperatorTokenSuccess() 
        {
            const string OPERATOR_SYMBOL = "*";
            var opToken = OperatorToken.CreateOperatorToken(OPERATOR_SYMBOL);
            Assert.AreEqual(OPERATOR_SYMBOL,opToken.ToString());
        }
        
        [Test]
        public void CreateDivisionOperatorTokenSuccess() 
        {
            const string OPERATOR_SYMBOL = "/";
            var opToken = OperatorToken.CreateOperatorToken(OPERATOR_SYMBOL);
            Assert.AreEqual(OPERATOR_SYMBOL,opToken.ToString());
        }
    }
}
