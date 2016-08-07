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

        public CharacterArticle(int articleId, string title, string description)
        {
            ArticleId = articleId;
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

        public override List<Panel> BuildControls()
        {
            var basePanels = base.BuildControls();
            var characterPanels = new List<Panel>();
            var moviesAppeared = WebControlBuilder.BuildLabelTextBoxPair("lblMoviesAppearedIn", "Movies appeared in", "MoviesAppearedIn",
                MoviesAppearedIn, TextBoxMode.MultiLine, rowSpan: 5);
            var fictionalCharacter = WebControlBuilder.BuildLabelCheckBoxPair("lblIsFictional", "Fictional character?", "IsFictional", IsFictional);
            characterPanels.Add(WebControlBuilder.BuildPanel(moviesAppeared.Item1, moviesAppeared.Item2));
            characterPanels.Add(WebControlBuilder.BuildPanel(fictionalCharacter.Item1, fictionalCharacter.Item2));

            // Insert all before the last description textarea
            basePanels.InsertRange(basePanels.Count - 1, characterPanels);

            return basePanels;
        }

        public override string ToString()
        {
            return "Character Article";
        }
    }
}