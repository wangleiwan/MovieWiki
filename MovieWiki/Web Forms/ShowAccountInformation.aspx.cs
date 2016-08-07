using MovieWiki.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Nick
// Added this web form

namespace MovieWiki.Web_Forms
{
    public partial class ShowAccountInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayAccountInformation();
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
    }
}