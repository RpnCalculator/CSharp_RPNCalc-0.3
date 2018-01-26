using System;
using System.IO;
using System.Linq;
using Csd.Calculator.TestDuplicates;
using Csd.Calculator.Token.Operator;
using NUnit.Framework;

namespace Csd.Calculator
{
    public class RPNCalculatorTest
    {
        private ConsoleOutputFake _fakeOutput;
        private RPNCalculator _calc;

        [SetUp]
        public void SetUp()
        {
            _fakeOutput = new ConsoleOutputFake();
            _calc = new RPNCalculator(_fakeOutput);
        }

        private void VerifyOutput(String[] expectedOutput)
        {
            String[] consoleOutput = _fakeOutput.GetStrings();

            Assert.AreEqual(expectedOutput.Length, consoleOutput.Length,"output line count");
            for (int i = 0; i < expectedOutput.Length; i++)
            {
               Assert.AreEqual(expectedOutput[i],consoleOutput[i]);
            }
        }

        [Test]
        public void SimpleAdditionGoodOutput()
        {
            TextReader input = new StringReader("5 3 +");
            String[] expectedOutput = { "[5]", "[5, 3]", "[5, 3, +]", "[8]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void SimpleSubtractionGoodOutput()
        {
            TextReader input = new StringReader("5 3 -");
            String[] expectedOutput = { "[5]", "[5, 3]", "[5, 3, -]", "[2]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void SimpleMultiplicationGoodOutput()
        {
            TextReader input = new StringReader("3 5 *");
            String[] expectedOutput = { "[3]", "[3, 5]", "[3, 5, *]", "[15]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);

        }

        [Test]
        public void SimpleDivisionGoodOutput()
        {
            TextReader input = new StringReader("21 3 /");
            String[] expectedOutput = { "[21]", "[21, 3]", "[21, 3, /]", "[7]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void DivideByZeroErrorMessage()
        {
            TextReader input = new StringReader("21 0 /");
            String[] expectedOutput = { "[21]", "[21, 0]", "[21, 0, /]", "Cannot divide by 0!", "[21]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void AdditionOperator_OneOperand_ErrorMessage()
        {
            TextReader input = new StringReader("5 +");
            String[] expectedOutput = { "[5]", "[5, +]", OperatorToken.OPERATOR_REQUIRES_TWO_OPERANDS, "[5]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }
        [Test]
        public void SubtractionOperator_OneOperand_ErrorMessage()
        {
            TextReader input = new StringReader("5 -");
            String[] expectedOutput = { "[5]", "[5, -]", OperatorToken.OPERATOR_REQUIRES_TWO_OPERANDS, "[5]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void MultiplicationOperator_OneOperand_ErrorMessage()
        {
            TextReader input = new StringReader("5 *");
            String[] expectedOutput = { "[5]", "[5, *]", OperatorToken.OPERATOR_REQUIRES_TWO_OPERANDS, "[5]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void DivisionOperator_OneOperand_ErrorMessage()
        {
            TextReader input = new StringReader("5 /");
            String[] expectedOutput = { "[5]", "[5, /]", OperatorToken.OPERATOR_REQUIRES_TWO_OPERANDS, "[5]" };
            _calc.ProcessInput(new StreamTokenizer(input));

            VerifyOutput(expectedOutput);
        }

        [Test]
        public void SingleWriteLineWithEmbeddedLfNoCrCombinedString()
        {
            _calc.WriteLine("Hello World\nToday is a great day to code.");
            var consoleOutput = _fakeOutput.GetStrings();

            Assert.AreEqual(1, consoleOutput.Count(), "wrong number of output lines");
            Assert.AreEqual("Hello World\nToday is a great day to code.", consoleOutput[0], "bad first line");
        }

        // fake output print lines
        [Test]
        public void SingleWriteLineWithEmbeddedCrlfCorrectOutputStrings()
        {
            _calc.WriteLine("Hello World\r\nToday is a great day to code.");
            var consoleOutput = _fakeOutput.GetStrings();

            Assert.AreEqual(2, consoleOutput.Length, "wrong number of output lines");
            Assert.AreEqual("Hello World", consoleOutput[0], "bad first line");
            Assert.AreEqual("Today is a great day to code.", consoleOutput[1], "bad second line");
        }

        [Test]
        public void MultipleWriteLineCorrectOutputStrings()
        {
            _calc.WriteLine("Hello World");
            _calc.WriteLine("Today is a great day to code.");
            var consoleOutput = _fakeOutput.GetStrings();

            Assert.AreEqual(2, consoleOutput.Length, "wrong number of output lines");
            Assert.AreEqual("Hello World", consoleOutput[0], "bad first line");
            Assert.AreEqual("Today is a great day to code.", consoleOutput[1], "bad second line");
        }

        [Test]
        public void DecimalAdditionGoodOutput()
        {
            TextReader input = new StringReader("5.75 3.2 +");
            String[] expectedOutput = { "[5.75]", "[5.75, 3.2]", "[5.75, 3.2, +]", "[8.95]" };

            _calc.ProcessInput(new StreamTokenizer(input));
            VerifyOutput(expectedOutput);
        }
    }
}
