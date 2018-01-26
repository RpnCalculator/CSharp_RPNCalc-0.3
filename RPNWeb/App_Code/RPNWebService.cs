using System;
using System.IO;
using System.Web.Services;
using Csd.Calculator;

/// <summary>
/// Summary description for RPNWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RPNWebService : System.Web.Services.WebService {

    public RPNWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string RPNCalculateEasyAddition(Int32 firstOperand, Int32 secondOperand)
    {
        TextReader input = new StringReader(string.Format("{0} {1} {2}", firstOperand, secondOperand, "+")); // example: ("5 3 +");

        StringWriter stringWriter = new StringWriter();
        RPNCalculator rpnCalculator = new RPNCalculator(stringWriter);

        rpnCalculator.ProcessInput(new StreamTokenizer(input));

        return stringWriter.GetStringBuilder().ToString();
    }

    [WebMethod]
    public string RPNCalculateEasySubtraction(Int32 firstOperand, Int32 secondOperand)
    {
        TextReader input = new StringReader(string.Format("{0} {1} {2}", firstOperand, secondOperand, "-")); // example: ("5 3 -");

        StringWriter stringWriter = new StringWriter();
        RPNCalculator rpnCalculator = new RPNCalculator(stringWriter);

        rpnCalculator.ProcessInput(new StreamTokenizer(input));

        return stringWriter.GetStringBuilder().ToString();
    }

    [WebMethod]
    public string RPNCalculateCalculateFromStream(string listOfTokens)
    {
        TextReader input = new StringReader(listOfTokens); 

        StringWriter stringWriter = new StringWriter();
        RPNCalculator rpnCalculator = new RPNCalculator(stringWriter);

        rpnCalculator.ProcessInput(new StreamTokenizer(input));

        return stringWriter.GetStringBuilder().ToString();
    }

}
