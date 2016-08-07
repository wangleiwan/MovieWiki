using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public abstract class PersonArticle : Article
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override List<TableRow> BuildControls(string[] parameters)
        {
            var baseRows = base.BuildControls(null);
            var personRows = new List<TableRow>();

            var name = WebControlBuilder.BuildLabelTextBoxPair("lblName", "Full name", "Name");
            personRows.Add(WebControlBuilder.BuildTableRow(name.Item1, name.Item2));
            var age = WebControlBuilder.BuildLabelTextBoxPair("lblAge", "Age", "Age");
            personRows.Add(WebControlBuilder.BuildTableRow(age.Item1, age.Item2));

            baseRows.InsertRange(1, personRows);

            return baseRows;
        }
    }
}