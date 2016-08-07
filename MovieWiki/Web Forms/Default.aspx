<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieWiki.Web_Forms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblWelcome" runat="server"></asp:Label><br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" /><br />
        <br />
        <a href="ChooseArticleToCreate.aspx">Create an article</a><br />
        <a href="SearchArticle.aspx">Search for an article</a><br />
        <a href="ShowAccountInformation.aspx">Account information</a><br />
        <a href="ShowRecentArticles.aspx">Recent articles</a><br />
    </div>
    </form>
</body>
</html>
