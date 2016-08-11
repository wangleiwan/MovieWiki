using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using MovieWiki.Custom_Classes;

namespace MovieWiki.Web_Forms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PromptLogin();
                
            }
        }

        private void PromptLogin()
        {
            var sessUserAccount = Session[Global.ActiveUserAccount];
            if (sessUserAccount == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                var userAccount = sessUserAccount as UserAccount;
                lblWelcome.Text = string.Format("Welcome to MovieWiki, <b>{0}</b>.", userAccount.Username);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session[Global.ActiveUserAccount] = null;
            Response.Redirect("Default.aspx");
        }

        protected void btnSearchArticle_ServerClick(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "myfunction();", true);
        }

        protected void btnsearchbtn_Click(object sender, EventArgs e)
        {
            var searchResultUrl = MovieWikiDbHelper.GetWikiArticleUrlBySearch(searchInput.Text);
            if (searchResultUrl != null)
            {
                Response.Redirect(searchResultUrl);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }
            
            
        }
    }
}