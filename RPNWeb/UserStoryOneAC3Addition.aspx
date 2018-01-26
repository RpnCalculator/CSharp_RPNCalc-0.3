<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserStoryOneAC3Addition.aspx.cs" Inherits="UserStoryOneAC3Addition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="mainForm" name="mainForm" action="UserStoryOneAC3Addition.aspx" method="get" runat="server">
    <div>
        <label>Enter List of Operands, followed by Operator (all delimited by spaces):</label><br />
        <asp:TextBox ID="stringOfTokens" runat="server"></asp:TextBox><br />        
        <input id="enterButton" type="submit" value="Calculate" /><br />
        <label>Answer:</label><br />
        <asp:TextBox runat="server" ID="answerText" style="width:400px;"></asp:TextBox><br />
    </div>
    </form>
    <br /><br />
    <a href="EasyAdditionUi.aspx">EasyAdditionUi page</a>
</body>
</html>