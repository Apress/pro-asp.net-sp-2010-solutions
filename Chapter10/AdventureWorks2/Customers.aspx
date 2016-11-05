<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customers.aspx.cs" MasterPageFile="~/_layouts/applicationv4.master" Inherits="Customers" %>
<asp:Content ID="contentMain" ContentPlaceHolderID="PlaceHolderMain" runat="server">
    <h1>AdventureWorks Customers</h1>
     <div>
     Customer:  <asp:DropDownList ID="ddCustomer" OnSelectedIndexChanged="ddCustomer_SelectedIndexChanged" AutoPostBack="True" runat="server">
        </asp:DropDownList>
          <asp:DetailsView ID="dvCustomerDetail" runat="server" Height="50px" Width="125px">
          </asp:DetailsView>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </div>
     <div><asp:HyperLink ID="hypDefault" runat="server" NavigateUrl="Default.aspx">Home</asp:HyperLink></div>
</asp:Content>
   