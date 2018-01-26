using System;
using NUnit.Framework;

namespace Csd.Calculator.Token
{
    public class OperandTokenTest
    {
        [Test]
        public void CreateTokenWithDoubleValue()
        {
            const double val = 3.1415;
            var number = new OperandToken(val);
            Assert.AreEqual(val, number.DoubleValue(), 0.001,"bad numeric value");
            Assert.AreEqual(val.ToString(), number.ToString(),"bad numeric value");
        }

        [Test]
        public void CreateTokenWithStringValue()
        {
            const string val = "3.1415";
            var number = new OperandToken(val);
            Assert.AreEqual(val, number.ToString(),"bad string value");
            Assert.AreEqual(Convert.ToDouble(val), number.DoubleValue(), 0.001, "bad numeric value");       
        }

        [Test, ExpectedException(typeof(FormatException))]
        public  void CreateTokenWithEmptyString_ThrowException()
        {
            new OperandToken("");
        }

        [Test]
        public void ToString_ReturnsTokenSymbolAsString()
        {
            CalculatorToken token = new OperandToken("5");
            Assert.AreEqual("5", token.ToString());
        }
    
        [Test]
        public void IsOperator_False() 
        {
            CalculatorToken token = new OperandToken("5");
            Assert.IsFalse(token.IsOperator());
        }
    }
}