<%@ Assembly Name="SPClientObjectModelECMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b3174228db6f7914" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientOMECMA.aspx.cs" Inherits="SPClientObjectModelECMA.Layouts.SPClientObjectModelECMA.ClientOMECMA" DynamicMasterPageFile="~masterurl/default.master" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PlaceHolderAdditionalPageHead" runat="server">
<script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery/jquery-1.3.2.min.js"  />  
<script type="text/ecmascript" src="/sites/blendedsolutions/_layouts/SPClientObjectModelECMA/TaskList.js"   />
<script type="text/javascript">
    $(document).ready(function () {
        $('.results').html = "Hello World"; 
    });
</script>
<SharePoint:ScriptLink ID="ScriptLink1" Name="sp.js" runat="server" LoadAfterUI="true" Localizable="false" ></SharePoint:ScriptLink>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
Here are the results:
<div class="results"></div>
<div id="error"></div>

<SharePoint:FormDigest ID="FormDigest1" runat="server" />
</asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Client Object Model using ECMAScript
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My ECMAScript Client Object Model
</asp:Content>
