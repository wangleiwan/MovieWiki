using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public class DirectorSection : RoleSection
    {
        public override List<Panel> BuildControls(string moviesDirectedContent = null)
        {

            var directorPanel = new List<Panel>();
            var moviesDirected = WebControlBuilder.BuildLabelTextBoxPair("lblMoviesDirected", "Movies directed", "DirectorSection",
                                moviesDirectedContent, TextBoxMode.MultiLine, rowSpan: 5);
            directorPanel.Add(WebControlBuilder.BuildPanel(moviesDirected.Item1, moviesDirected.Item2));

            return directorPanel;
        }
    }
}