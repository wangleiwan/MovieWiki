<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchArticle.aspx.cs" Inherits="MovieWiki.Web_Forms.SearchArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="Default.aspx"><-- Back</a><br />
        <br />
        <asp:TextBox ID="txtSearch" runat="server" Width="128px" />
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Width="61px" />
        <br /><br />
        <asp:Label ID="lblNoResults" runat="server"></asp:Label>
        <asp:Panel id="pSearchResults" runat="server">
        </asp:Panel>
        <asp:Panel ID="placeholder" CssClass="panel panel-default" runat="server">

        </asp:Panel>
        <asp:Button ID="btnStuff" OnClick="btnStuff_Click" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
