<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillArticleContents.aspx.cs" Inherits="MovieWiki.Web_Forms.FillArticleContents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery-3.1.0.min.js"></script>
    <script src="../js/bootstrap.min.js" ></script>
    <title></title>
</head>
<body>
    <form id="form1" class="form-horizontal" runat="server">
        <div class="form-group">
            <a href="ChooseArticleToCreate.aspx"><-- Back</a><br />
            <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblArticleTemplateHeader" Font-Bold="true" Font-Size="Larger" runat="server" /><br />
            <br />
            <asp:Table ID="tblArticleContent" runat="server" /><br />
            <asp:Button ID="btnCreateArticle" runat="server" OnClick="btnCreateArticle_Click" Text="Create article" />
        </div>
    </form>
</body>
</html>
