using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MovieWiki.Custom_Classes
{
    public class CharacterArticle : PersonArticle
    {
        public string MoviesAppearedIn { get; set; }
        public bool IsFictional { get; set; }

        public CharacterArticle() { }

        public CharacterArticle(int articleId, int author, string title, string description)
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
            MoviesAppearedIn = xml.Elements("MoviesAppearedIn").FirstOrDefault().Value;
            IsFictional = Convert.ToBoolean(xml.Elements("IsFictional").FirstOrDefault().Value);
        }

        public override List<TableRow> BuildControls(string[] parameters)
        {
            var baseRows = base.BuildControls(null);
            var characterRows = new List<TableRow>();
            var moviesAppeared = WebControlBuilder.BuildLabelTextBoxPair("lblMoviesAppearedIn", "Movies appeared in", "MoviesAppearedIn",
                TextBoxMode.MultiLine, rowSpan: 5);
            var fictionaryCharacter = WebControlBuilder.BuildLabelCheckBoxPair("lblIsFictional", "Fictional character?", "IsFictional");
            characterRows.Add(WebControlBuilder.BuildTableRow(moviesAppeared.Item1, moviesAppeared.Item2));
            characterRows.Add(WebControlBuilder.BuildTableRow(fictionaryCharacter.Item1, fictionaryCharacter.Item2));

            // Insert all before the last description textarea
            baseRows.InsertRange(baseRows.Count - 1, characterRows);

            return baseRows;
        }

        public override string ToString()
        {
            return "Character Article";
        }
    }
}