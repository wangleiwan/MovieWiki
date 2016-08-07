using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public class ActorSection : RoleSection
    {
        public override List<TableRow> BuildControls()
        {
            var actorRows = new List<TableRow>();
            var charactersPortrayed = WebControlBuilder.BuildLabelTextBoxPair("lblCharactersPortrayed", "Characters portrayed", "ActorSection",
                                TextBoxMode.MultiLine, rowSpan: 5);
            actorRows.Add(WebControlBuilder.BuildTableRow(charactersPortrayed.Item1, charactersPortrayed.Item2));

            return actorRows;
        }
    }
}