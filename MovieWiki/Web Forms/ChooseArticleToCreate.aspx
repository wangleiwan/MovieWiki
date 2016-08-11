<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseArticleToCreate.aspx.cs" Inherits="MovieWiki.Web_Forms.ChooseArticleToCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js" ></script>
    <script src="../js/script.js"></script>
    <title>Create an Article</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager runat="server" />
        <div class="container">
        <nav class="navbar navbar-default">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="container-fluid">
                <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                  </button>
                  <a class="navbar-brand" href="#">
                      <img id="brandIcon" alt="Brand" src="../images/movie-icon.png"/>
                  </a>
                </div>                
            <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                  <div class="navbar-form navbar-left">
                      <div class="row titleSearch">
                          <div class="col-lg-3">
                            <div class="title">Movie Wiki</div>
                          </div>
                          <div class="col-lg-9">
                             <div class="input-group">
                                <asp:TextBox runat="server" ID="searchInput" CssClass="form-control" placeholder="Search for an article..."/>
                                <span class="input-group-btn">
                                  <button runat="server" id="btnsearchbtn" data-toggle="modal" class="btn btn-default" onserverclick="btnsearchbtn_Click">
                                      <i class="fa fa-search"></i>
                                  </button>
                                </span>
                             </div>
                          </div>
                        </div>
                    </div>
                  <button runat="server" id="btnSignIn" type="button" class="btn btn-default navbar-btn navbar-right" CausesValidation="False" onserverclick="btnLogout_Click">Log out</button>
                </div><!-- /.navbar-collapse -->
             </div>
          </nav>
      </div>
      <div class="modalSection">
        <div class="modal fade" tabindex="-1" role="dialog" id="myModal">
          <div class="modal-dialog" role="document">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                      <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" ><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title text-center">No Result Found</h4>
                      </div>
                    </div><!-- /.modal-content -->
               </ContentTemplate>
            </asp:UpdatePanel>
          </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->
      </div>

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
