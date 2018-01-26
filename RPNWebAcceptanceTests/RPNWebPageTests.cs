using NUnit.Framework;
using WatiN.Core;

namespace RPNWebAcceptanceTests
{
    [TestFixture]
    public class RPNWebPageTests
    {
        [Test]
        public void EasyAdditionPageCalculatesCorrectAnswer()
        {
            var browser = new IE("http://localhost:58686/PRNWeb/EasyAdditionUi.aspx");
            browser.TextField(Find.ByName("firstOperand")).TypeText("6");
            browser.TextField(Find.ByName("secondOperand")).TypeText("5");
            browser.Button(Find.ById("enterButton")).Click();
            Assert.AreEqual("[6][6, 5][6, 5, +][11]", browser.TextField(Find.ByName("answerText")).Text, "Clicking the calculate button did not produce the correct answer. ");
        }
    }
}
