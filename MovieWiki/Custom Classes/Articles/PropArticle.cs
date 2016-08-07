using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MovieWiki.Custom_Classes
{
    public class PropArticle : Article
    {
        public string MoviesFeaturedIn { get; set; }
        public string Function { get; set; }

        public PropArticle() { }

        public PropArticle(int articleId, int author, string title, string description)
        {
            ArticleId = articleId;
            Author = author;
            Title = title;
            ParseData(description);
        }

        public override void ParseData(string articleData)
        {
            base.ParseData(articleData);
            var xml = XElement.Parse(articleData);
            MoviesFeaturedIn = xml.Elements("MoviesFeaturedIn").FirstOrDefault().Value;
            Function = xml.Elements("Function").FirstOrDefault().Value;
        }

        public override List<TableRow> BuildControls(string[] parameters)
        {
            var baseRows = base.BuildControls(null);
            var propRows = new List<TableRow>();
            var moviesFeatured = WebControlBuilder.BuildLabelTextBoxPair("lblMoviesFeaturedIn", "Movies featured in", "MoviesFeaturedIn",
                TextBoxMode.MultiLine, rowSpan: 5);
            var function = WebControlBuilder.BuildLabelTextBoxPair("lblFunction", "Function", "Function");
            propRows.Add(WebControlBuilder.BuildTableRow(moviesFeatured.Item1, moviesFeatured.Item2));
            propRows.Add(WebControlBuilder.BuildTableRow(function.Item1, function.Item2));

            baseRows.InsertRange(1, propRows);

            return baseRows;
        }

        public override string ToString()
        {
            return "Prop Article";
        }
    }
}