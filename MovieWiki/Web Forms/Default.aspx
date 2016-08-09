<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieWiki.Web_Forms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js" ></script>
    <script src="../js/script.js"></script>
    <title>Welcome To Movie Wiki</title>
</head>
<body>
    <form id="form1" runat="server">
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
                                <input id="searchInput" type="text" class="form-control" placeholder="Search for an article..."/>
                                <span class="input-group-btn">
                                  <button runat="server" id="btnSearchbtn" class="btn btn-default" type="button">
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
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onserverclick="btnSearchArticle_ServerClick"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title text-center">No Result Found</h4>
              </div>
            </div><!-- /.modal-content -->
          </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->
      </div>

    <div>
        <asp:Label ID="lblWelcome" runat="server"></asp:Label><br />
        <%--<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" /><br />--%>
        <br />
        <a href="ChooseArticleToCreate.aspx">Create an article</a><br />
        <a href="SearchArticle.aspx">Search for an article</a><br />
        <a href="ShowAccountInformation.aspx">Account information</a><br />
        <a href="ShowRecentArticles.aspx">Recent articles</a><br />
    </div>
    </form>
</body>
</html>
