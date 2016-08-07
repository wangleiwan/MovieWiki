<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillArticleContents.aspx.cs" Inherits="MovieWiki.Web_Forms.FillArticleContents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.js"></script>
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
        <div class="container">
            <form id="form1" runat="server">
                <div class="content">
                    <div class="logInSection">
                        <div class="panel panel-info">
                
                            <asp:Panel ID="panelHeading" CssClass="panel-heading" runat="server">
                                <asp:Label CssClass="text-center loginTitle" ID="lblArticleTemplateHeader" Font-Bold="true" Font-Size="Larger" runat="server" />
                            </asp:Panel>
                            <div class="panel-body">
                                <asp:Panel ID="pnlArticleContent" runat="server" CssClass="form-horizontal"></asp:Panel>
                            </div>
                      
                        </div>
                    </div>
                </div>
    
                <div>
                    <%--Nick
                    Can this back <a> tag be moved to the top of the screen?--%>
                    <a href="ChooseArticleToCreate.aspx"><-- Back</a><br />
                    <asp:Label ID="lblError" ForeColor="Red" runat="server"></asp:Label>
                    <br />
                    <asp:Button ID="btnCreateArticle" CausesValidation="true" ValidationGroup="vldArticleTemplateControls" runat="server" OnClick="btnCreateArticle_Click" Text="Create article" />
                </div>
        </form>
       </div>
  
</body>
</html>
