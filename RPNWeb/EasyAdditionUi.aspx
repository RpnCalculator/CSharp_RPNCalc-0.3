<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EasyAdditionUi.aspx.cs" Inherits="EasyAdditionUi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="mainForm" name="mainForm" action="EasyAdditionUi.aspx" method="get" runat="server">
    <div>
        <label>Enter First Operand:</label><br />
        <asp:TextBox ID="firstOperand" runat="server"></asp:TextBox><br />
        <label>Enter Second Operand</label><br />
        <asp:TextBox ID="secondOperand" runat="server"></asp:TextBox><br />
        
        <input id="enterButton" type="submit" value="Calculate" /><br />
        <label>Answer:</label><br />
        <asp:TextBox runat="server" ID="answerText" style="width:400px;"></asp:TextBox><br />
    </div>
    </form>
    <br /><br />
    <a href="UserStoryOneAC3Addition.aspx" >UserStoryOneAC3Addition page</a>
</body>
</html>
