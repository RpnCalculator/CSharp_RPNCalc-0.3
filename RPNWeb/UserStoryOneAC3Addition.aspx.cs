using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserStoryOneAC3Addition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Calculate();
        }
    }

    protected void Calculate()
    {
        RPNWebService rpnWebService = new RPNWebService();
        string answer = rpnWebService.RPNCalculateCalculateFromStream(stringOfTokens.Text);
        answerText.Text = answer;
    }
}