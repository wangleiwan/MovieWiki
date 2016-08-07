using MovieWiki.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWiki.Web_Forms
{
    public partial class SearchArticle : System.Web.UI.Page
    {
        private const string PrevSearch = "PrevSearch";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var homepageSearch = Request.QueryString["search"];
                if (homepageSearch != null)
                {
                    ExecuteSearch(homepageSearch);
                }
                txtSearch.Attributes.Add("Placeholder", "Enter an article title");

                var prevSearchResults = Session[PrevSearch] as List<HyperLink>;
                if (prevSearchResults != null)
                {
                    DisplayResults(prevSearchResults);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ExecuteSearch(txtSearch.Text);
        }

        // TODO right now it searches for article titles. should it search by any other parameters?
        private void ExecuteSearch(string search)
        {
            pSearchResults.Controls.Clear();
            var searchHyperLinks = new List<HyperLink>();

            var matchingArticles = from article in MovieWikiDbHelper.AllWikiArticles
                                   where (string.IsNullOrWhiteSpace(search)
                                       || string.Equals(search, article.Title, StringComparison.OrdinalIgnoreCase))
                                   orderby article.ArticleId descending
                                   select article;

            foreach (var article in matchingArticles)
            {
                var hyperLink = WebControlBuilder.BuildHyperLink(article.Title,
                    string.Format(Global.ShowArticleUrlWithId, article.ArticleId));
                searchHyperLinks.Add(hyperLink);
            }

            DisplayResults(searchHyperLinks);
            Session.Add(PrevSearch, searchHyperLinks);
        }

        private void DisplayResults(List<HyperLink> matchingArticleLinks)
        {
            pSearchResults.Controls.Clear();
            lblNoResults.Text = string.Empty;

            if (matchingArticleLinks.Count == 0) lblNoResults.Text = "No results found.";

            foreach (var link in matchingArticleLinks)
            {
                pSearchResults.Controls.Add(link);
                pSearchResults.Controls.Add(new LiteralControl("<br />"));
            }
        }

        protected void btnStuff_Click(object sender, EventArgs e)
        {
            Label lblLabel = new Label();
            lblLabel.CssClass = "this";
            lblLabel.Text = "More Of this";
            placeholder.Controls.Add(lblLabel);
        }
    }
}