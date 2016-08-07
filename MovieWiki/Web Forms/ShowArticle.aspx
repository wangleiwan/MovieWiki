<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowArticle.aspx.cs" Inherits="MovieWiki.Web_Forms.ShowArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="SearchArticle.aspx""><-- Back</a><br />
        <br />
        <asp:Button ID="btnEditSave" runat="server" Text="Edit" OnClick="btnEditSave_Click" />
        <asp:Button ID="btnDeleteArticle" runat="server" Visible="false" Text="Delete" OnClick="btnDeleteArticle_Click" /><br />
        <br />
        <asp:Panel ID="pnlArticleContent" runat="server" /><br />
        <br />
    </div>
    </form>
</body>
</html>
