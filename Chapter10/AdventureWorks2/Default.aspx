<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" MasterPageFile="~/_layouts/applicationv4.master" Inherits="_Default" %>
<asp:Content ID="contentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">
<h1>AdventureWorks Pages</h1>
<div>
    <ul>
        <li><asp:HyperLink ID="hypCustomers" runat="server" NavigateUrl="Customers.aspx">Customers</asp:HyperLink></li>
        <li><asp:HyperLink ID="hypOrders" runat="server" NavigateUrl="Orders.aspx">Orders</asp:HyperLink></li>
    </ul>
</div>
</asp:Content>
   
