//Contributors: Lei Wang

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        public void DisplayAccountInformation()
        {
            var activeUser = Session[Global.ActiveUserAccount] as UserAccount;
            lblGreeting.Text = string.Format("Account details for: <b>{0}</b>", activeUser.Username);

            var userArticleEdits = from edit in MovieWikiDbHelper.AllWikiArticleEditHistories
                                   join article in MovieWikiDbHelper.AllWikiArticles
                                   on edit.ArticleId equals article.ArticleId
                                   where edit.AccountId == activeUser.AccountId
                                   orderby edit.EditTimestamp descending
                                   select new { Article = article, Edit = edit };

            lblArticleEdits.Visible = userArticleEdits.Count() > 0;

            foreach (var userArticleEdit in userArticleEdits)
            {
                var hyperLinkText = userArticleEdit.Article.Title;
                var timeStampLabel = new Label { Text = string.Format(" {0}, {1}",
                    userArticleEdit.Edit.EditTimestamp.ToShortDateString(), userArticleEdit.Edit.EditTimestamp.ToLongTimeString()) };
                var hyperLink = WebControlBuilder.BuildHyperLink(hyperLinkText,
                    string.Format(Global.ShowArticleUrlWithId, userArticleEdit.Article.ArticleId));
                pUserEdits.Controls.Add(hyperLink);
                pUserEdits.Controls.Add(timeStampLabel);
                pUserEdits.Controls.Add(new LiteralControl("<br />"));
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session[Global.ActiveUserAccount] = null;
            Response.Redirect("Default.aspx");
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal('show');", true);
                upModal.Update();
                
            }
        }

        protected void showAccountInfo_ServerClick(object sender, EventArgs e)
        {
            DisplayAccountInformation();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "AccountModal", "$('#AccountModal').modal();", true);
            updateAccount.Update();
        }

        protected void showRecentModal_ServerClick(object sender, EventArgs e)
        {
            DisplayRecentArticles();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RecentModal", "$('#RecentModal').modal();", true);
            upRecentModal.Update();
        }

        private void DisplayRecentArticles()
        {

            var recentArticles = (from edit in MovieWikiDbHelper.AllWikiArticleEditHistories
                                  join article in MovieWikiDbHelper.AllWikiArticles
                                  on edit.ArticleId equals article.ArticleId
                                  orderby edit.EditTimestamp descending
                                  select article).Distinct().Take(10);
            
            int result = recentArticles.Count();
            
            lblRecentEdits.Text = recentArticles.Count() > 0
                ? result + " articles most recently contributed to:"
                : "No articles were created yet";

            foreach (var recentArticle in recentArticles)
            {
                var hyperLinkText = recentArticle.Title;
                var hyperLink = WebControlBuilder.BuildHyperLink(hyperLinkText,
                    string.Format(Global.ShowArticleUrlWithId, recentArticle.ArticleId));
                pUserEditsRecent.Controls.Add(hyperLink);
                pUserEditsRecent.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}