using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace MovieWiki.Custom_Classes
{
    public class MovieArticle : Article
    {
        public string Theme { get; set; }
        public string Characters { get; set; }
        // change to TimeSpan?
        public string Duration { get; set; }

        public MovieArticle() { }

        public MovieArticle(int articleId, int author, string title, string description)
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
            Theme = xml.Elements("Theme").FirstOrDefault().Value;
            Characters = xml.Elements("Characters").FirstOrDefault().Value;
            Duration = xml.Elements("Duration").FirstOrDefault().Value;
        }

        public override List<TableRow> BuildControls(string[] parameters)
        {
            var baseRows = base.BuildControls(null);

            var movieRows = new List<TableRow>();
            var theme = WebControlBuilder.BuildLabelTextBoxPair("lblTheme", "Theme", "Theme");
            var characters = WebControlBuilder.BuildLabelTextBoxPair("lblCharacters", "Characters", "Characters",
                TextBoxMode.MultiLine, rowSpan: 5);
            var language = WebControlBuilder.BuildLabelTextBoxPair("lblLanguage", "Language", "Language");
            var duration = WebControlBuilder.BuildLabelTextBoxPair("lblDuration", "Duration", "Duration");
            movieRows.Add(WebControlBuilder.BuildTableRow(theme.Item1, theme.Item2));
            movieRows.Add(WebControlBuilder.BuildTableRow(characters.Item1, characters.Item2));
            movieRows.Add(WebControlBuilder.BuildTableRow(language.Item1, language.Item2));
            movieRows.Add(WebControlBuilder.BuildTableRow(duration.Item1, duration.Item2));

            baseRows.InsertRange(1, movieRows);

            return baseRows;
        }

        public override string ToString()
        {
            return "Movie Article";
        }
    }
}