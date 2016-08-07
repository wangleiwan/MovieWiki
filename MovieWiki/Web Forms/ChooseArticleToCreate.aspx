<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseArticleToCreate.aspx.cs" Inherits="MovieWiki.Web_Forms.ChooseArticleToCreate" %>

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
        <h3>Create a MovieWiki article template</h3>
        <h4>What type of article would you like to create?</h4>
        <asp:CustomValidator runat="server"
                        ID="vldArticle"
                        ValidationGroup="vldArticles"
                        OnServerValidate="vldArticle_ServerValidate"
                        ForeColor="Red" /><br />
        <asp:RadioButton ID="rbMovieArticle" ValidationGroup="vldArticles" GroupName="rbArticles" Text="Movie" OnCheckedChanged="rbMovieArticle_CheckedChanged" AutoPostBack="true" runat="server" /><br />
        <asp:RadioButton ID="rbPersonArticle" ValidationGroup="vldArticles" GroupName="rbArticles" Text="Person" OnCheckedChanged="rbPersonArticle_CheckedChanged" AutoPostBack="true" runat="server" /><br />
        <div id="personArticleTypes" runat="server" style="margin-left: 30px">
            <asp:RadioButton ID="rbPersonCrewMemberArticle" ValidationGroup="vldArticles" GroupName="rbPersonArticles" Text="Crew member" OnCheckedChanged="rbPersonCrewMemberArticle_CheckedChanged" AutoPostBack="true" runat="server" /><br />
            <div id="personCrewMemberRoles" runat="server" style="margin-left: 60px">
                <asp:CheckBox ID="chbActor" ValidationGroup="vldArticles" Text="Actor" runat="server" /><br />
                <asp:CheckBox ID="chbDirector" ValidationGroup="vldArticles" Text="Director" runat="server" /><br />
                <asp:CheckBox ID="chbProducer" ValidationGroup="vldArticles" Text="Producer" runat="server" /><br />
            </div>
            <asp:RadioButton ID="rbPersonCharacterArticle" ValidationGroup="vldArticles" GroupName="rbPersonArticles" Text="Movie character" OnCheckedChanged="rbPersonCharacterArticle_CheckedChanged" AutoPostBack="true" runat="server" /><br />
        </div>
        <asp:RadioButton ID="rbPropArticle" ValidationGroup="vldArticles" GroupName="rbArticles" Text="Prop" OnCheckedChanged="rbPropArticle_CheckedChanged" AutoPostBack="true" runat="server" /><br />
        <br />
        <asp:Button ID="btnCreateTemplate" ValidationGroup="vldArticles" runat="server" Text="Create article template" OnClick="btnCreateTemplate_Click" />
    </div>
    </form>
</body>
</html>
