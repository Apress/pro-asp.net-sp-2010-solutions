<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientOMWebApp1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Tasks Through Client Object Model</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="SharePoint Site Collection:  "/>
    <asp:TextBox ID="txtSiteCollection" runat="server" Width="350"></asp:TextBox>
    <br />
    <asp:Button ID="btnGetTasks" runat="server" Text="Get Tasks" onclick="btnGetTasks_Click" />
    <br />
    <asp:Label ID="lblTasks" runat="server" />
    </div>
    </form>
</body>
</html>
