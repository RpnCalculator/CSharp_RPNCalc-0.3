using NUnit.Framework;
using RPNWebAcceptanceTests.ServiceReference1;

namespace RPNWebAcceptanceTests
{
    [TestFixture]
    public class RPNWebServicesTests
    {
        [Test]
        public void EasyAdditionReturnsResultForTwoPlusTwo()
        {
            RPNWebServiceSoapClient rpnWebServiceSoapClient = new RPNWebServiceSoapClient();
            string answer = rpnWebServiceSoapClient.RPNCalculateEasyAddition(2, 2);
            Assert.AreEqual("[2]\n[2, 2]\n[2, 2, +]\n[4]\n", answer, "RPNCalculateEasyAddition returned the wrong answer.");
        }

        [Test]
        public void EasySubtractionReturnsCorrectResultForTenMinusOne()
        {
            RPNWebServiceSoapClient rpnWebServiceSoapClient = new RPNWebServiceSoapClient();
            string answer = rpnWebServiceSoapClient.RPNCalculateEasySubtraction(10, 1);
            Assert.AreEqual("[10]\n[10, 1]\n[10, 1, -]\n[9]\n", answer, "RPNCalculateEasySubtraction returned the wrong answer.");
        }

        [Test]
        public void EasySubtractionReturnsCorrectResultForTenMinusTwo()
        {
            RPNWebServiceSoapClient rpnWebServiceSoapClient = new RPNWebServiceSoapClient();
            string answer = rpnWebServiceSoapClient.RPNCalculateEasySubtraction(10, 2);
            Assert.AreEqual("[10]\n[10, 2]\n[10, 2, -]\n[8]\n", answer, "RPNCalculateEasySubtraction returned the wrong answer.");
        }


        [Test]
        public void ServiceReturnsCorrectResultForStringOfOperandsWithPlusSignAtTheEnd()
        {
            RPNWebServiceSoapClient rpnWebServiceSoapClient = new RPNWebServiceSoapClient();
            string answer = rpnWebServiceSoapClient.RPNCalculateCalculateFromStream("2 1 +");
            Assert.AreEqual("[2]\n[2, 1]\n[2, 1, +]\n[3]\n", answer, "RPNCalculateCalculateFromStream returned the wrong answer.");
        }
    }
}
