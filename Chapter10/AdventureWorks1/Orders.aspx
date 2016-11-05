<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Orders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>AdventureWorks Orders</h1>
   <div>
      Sales Order:  <asp:DropDownList ID="ddSalesOrder" OnSelectedIndexChanged="ddSalesOrder_SelectedIndexChanged" AutoPostBack="True" runat="server">
        </asp:DropDownList>
        <asp:GridView ID="gvSalesOrderDetail" runat="server">
        </asp:GridView>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </div>
    <div><asp:HyperLink ID="hypDefault" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink></div>
    </form>
</body>
</html>
