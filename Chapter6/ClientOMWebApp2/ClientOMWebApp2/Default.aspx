<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ClientOMWebApp2._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="SharePoint Site Collection:  "/>
    <asp:TextBox ID="txtSiteCollection" runat="server" Width="350"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Title:  "/>
    <asp:TextBox ID="txtTitle" runat="server" Width="250"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Description:  "/>
    <asp:TextBox ID="txtDesc" runat="server" Width="350"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Due Date:  "/>
    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
    <br />
    <asp:Button ID="btnAddTask" runat="server" Text="Add Task" 
            onclick="btnAddTask_Click" />
    <br />
     <asp:Label ID="lblResult" runat="server" Text=""/>
    </div>
    </form>
</body>
</html>
