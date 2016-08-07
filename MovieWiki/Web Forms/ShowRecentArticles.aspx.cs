using MovieWiki.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWiki.Web_Forms
{
    public partial class ShowRecentArticles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRecentArticles();
        }

        private void DisplayRecentArticles()
        {

            var recentArticles = (from edit in MovieWikiDbHelper.AllWikiArticleEditHistories
                                 join article in MovieWikiDbHelper.AllWikiArticles
                                 on edit.ArticleId equals article.ArticleId
                                 orderby edit.EditTimestamp descending
                                 select article).Distinct().Take(10);

            lblRecentEdits.Text = recentArticles.Count() > 0 
                ? "10 articles most recently contributed to:"
                : "No articles were created yet";

            foreach (var recentArticle in recentArticles)
            {
                var hyperLinkText = recentArticle.Title;
                var hyperLink = WebControlBuilder.BuildHyperLink(hyperLinkText,
                    string.Format(Global.ShowArticleUrlWithId, recentArticle.ArticleId));
                pUserEdits.Controls.Add(hyperLink);
                pUserEdits.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}