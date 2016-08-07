using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public class DirectorSection : RoleSection
    {
        public override List<TableRow> BuildControls()
        {
            var directorRows = new List<TableRow>();
            var moviesDirected = WebControlBuilder.BuildLabelTextBoxPair("lblMoviesDirected", "Movies directed", "DirectorSection",
                                TextBoxMode.MultiLine, rowSpan: 5);
            directorRows.Add(WebControlBuilder.BuildTableRow(moviesDirected.Item1, moviesDirected.Item2));

            return directorRows;
        }
    }
}