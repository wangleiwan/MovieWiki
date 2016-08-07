using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public class ProducerSection : RoleSection
    {
        public override List<TableRow> BuildControls()
        {
            var producerRows = new List<TableRow>();
            var moviesProduced = WebControlBuilder.BuildLabelTextBoxPair("lblMoviesProduced", "Movies produced", "ProducerSection",
                                TextBoxMode.MultiLine, rowSpan: 5);
            producerRows.Add(WebControlBuilder.BuildTableRow(moviesProduced.Item1, moviesProduced.Item2));

            return producerRows;
        }
    }
}