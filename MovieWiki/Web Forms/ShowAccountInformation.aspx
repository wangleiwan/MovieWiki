<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAccountInformation.aspx.cs" Inherits="MovieWiki.Web_Forms.ShowAccountInformation" %>

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
        <asp:Label ID="lblGreeting" runat="server" /><br />
        <br />
        <asp:Label ID="lblArticleEdits" runat="server" Text="Your article contributions:" Visible="false"></asp:Label>
        <asp:Panel id="pUserEdits" runat="server">

        </asp:Panel>
    </div>
    </form>
</body>
</html>
