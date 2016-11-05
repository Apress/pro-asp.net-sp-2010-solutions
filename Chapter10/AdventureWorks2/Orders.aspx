<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Orders.aspx.cs" MasterPageFile="~/_layouts/applicationv4.master" Inherits="Orders" %>
<asp:Content ID="contentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <h1>AdventureWorks Orders</h1>
   <div>
      Sales Order:  <asp:DropDownList ID="ddSalesOrder" OnSelectedIndexChanged="ddSalesOrder_SelectedIndexChanged" AutoPostBack="True" runat="server">
        </asp:DropDownList>
        <asp:GridView ID="gvSalesOrderDetail" runat="server">
        </asp:GridView>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </div>
    <div><asp:HyperLink ID="hypDefault" runat="server" NavigateUrl="Default.aspx">Home</asp:HyperLink></div>
</asp:Content>