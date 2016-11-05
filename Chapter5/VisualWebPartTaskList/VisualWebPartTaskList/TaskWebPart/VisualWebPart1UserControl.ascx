<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="VisualWebPartTaskList.VisualWebPart1.VisualWebPart1UserControl" %>
<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
<asp:Label ID="Label1" runat="server" Text="Task:"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
<asp:Label ID="Label2" runat="server" Text="Description:"></asp:Label>
<asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox><br />
<asp:Button ID="Button1" runat="server" Text="Add Task" 
    onclick="Button1_Click" /><br />
<asp:Label ID="lblResults" runat="server"></asp:Label>


