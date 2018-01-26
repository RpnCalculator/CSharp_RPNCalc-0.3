using System;

public partial class EasyAdditionUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack)
        {
            Calculate();
        }
    }

    protected void Calculate()
    {
        RPNWebService rpnWebService = new RPNWebService();
        string answer = rpnWebService.RPNCalculateEasyAddition(int.Parse(firstOperand.Text), int.Parse(secondOperand.Text));
        answerText.Text = answer;
    }
}