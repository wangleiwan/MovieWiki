using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieWiki.Custom_Classes;
using System.Xml.Linq;

namespace MovieWiki.Web_Forms
{
    public partial class FillArticleContents : System.Web.UI.Page
    {
        private ArticleFactory _articleFactory = new ArticleFactory();
        private Article _article;

        protected void Page_Load(object sender, EventArgs e)
        {
            var articleType = Request.QueryString["articleType"];
            if (articleType == null)
            {
                Response.Redirect("ChooseArticleToCreate.aspx");
            }

            var queryStringParameters = Request.QueryString["parameters"];
            var parametersSplit = queryStringParameters == null
                ? null
                : queryStringParameters.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            _article = _articleFactory.GetInstance(articleType, parametersSplit);
            lblArticleTemplateHeader.Text = string.Format("{0} Template", _article.ToString());
            
            BuildArticleTemplate(parametersSplit);
        }

        private void BuildArticleTemplate(string[] parameters)
        {
            var tableRows = _article.BuildControls(parameters);

            foreach (var row in tableRows)
            {
                tblArticleContent.Controls.Add(row);
            }
        }

        // TODO redirect to newly created article page after create button clicked
        protected void btnCreateArticle_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;  // to clear any error text
            var xml = _article.ComposeXml(tblArticleContent);
            var author = Session[Global.ActiveUserAccount] as UserAccount;
            var title = xml.Elements("Title").FirstOrDefault().Value;
            var timestamp = DateTime.Now;

            if (MovieWikiDbHelper.InsertWikiArticle(author.AccountId, _article.GetType().Name, title, xml.ToString()))
            {
                // Reassign _article now that all the properties are properly set
                _article = MovieWikiDbHelper.GetWikiArticle(title);
                MovieWikiDbHelper.InsertWikiArticleEditHistory(_article.ArticleId, author.AccountId, timestamp);

                Session[Global.ActiveArticle] = _article;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Text = "An article with that title already exists";
            }
        }
    }
}