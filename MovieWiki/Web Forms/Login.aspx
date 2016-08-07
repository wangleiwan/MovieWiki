﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MovieWiki.Web_Forms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery-3.1.0.min.js"></script>
    <script src="../js/bootstrap.min.js" ></script>
    <title>Login</title>
</head>
<body>
    <!--<div class="container">-->
        <asp:Panel CssClass="container" runat="server">
        <div class="content">
            <div class="logInSection">
              <div class="panel panel-info">
                <div class="panel-heading">
                    <div class="text-center loginTitle">Please Log In</div>
                </div>
                <div class="panel-body">
                  <form class="form-horizontal" runat="server">
                  <div class="form-group">
                    <asp:Label ID="lblUsername" runat="server" Text="Username" class="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                      <asp:TextBox class="form-control" ID="txtUsername" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="vldUsername" ForeColor="Red" runat="server" ErrorMessage="Enter a username" ControlToValidate="txtUsername" />
                    </div>
                  </div>
                  <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password" class="col-sm-2 control-label"></asp:Label>
                    <div class="col-sm-10">
                      <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="vldPassword" ForeColor="Red" runat="server" ErrorMessage="Enter a password" ControlToValidate="txtPassword" />
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-2">
                        <asp:Button class="btn btn-primary" ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button class="btn btn-primary" ID="btnRegister" CausesValidation="false" runat="server" Text="Register" OnClick="btnRegister_Click" />
                    </div>
                  </div>
                  <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
                </form>
                </div>
             </div>
         </div>
      </div>
            </asp:Panel>
  <!--</div>-->
    
</body>
</html>