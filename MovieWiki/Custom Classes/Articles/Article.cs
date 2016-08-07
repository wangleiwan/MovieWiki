using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MovieWiki.Custom_Classes
{
    public abstract class Article
    {
        public int ArticleId { get; set; }
        public int Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual void ParseData(string articleData)
        {
            var xml = XElement.Parse(articleData);
            Description = xml.Elements("Description").FirstOrDefault().Value;
            Title = xml.Elements("Title").FirstOrDefault().Value;
        }

        public virtual List<TableRow> BuildControls(string[] parameters)
        {
            var tableRows = new List<TableRow>();

            var title = WebControlBuilder.BuildLabelTextBoxPair("lblTitle", "Title", "Title");
            tableRows.Add(WebControlBuilder.BuildTableRow(title.Item1, title.Item2));

            var description = WebControlBuilder.BuildLabelTextBoxPair("lblDescription", "Description", "Description",
                TextBoxMode.MultiLine, 40, 20);
            tableRows.Add(WebControlBuilder.BuildTableRow(description.Item1, description.Item2));

            return tableRows;
        }

        // Serializes ASP table content into database-ready XML
        public virtual XElement ComposeXml(Control table)
        {
            var xml = new XElement(this.GetType().Name);
            foreach (Control tableRows in table.Controls)
            {
                var tr = tableRows as TableRow;
                foreach (var tableCells in tr.Controls)
                {
                    var td = tableCells as TableCell;
                    foreach (var child in td.Controls)
                    {
                        var textBox = child as TextBox;
                        if (textBox != null)
                        {
                            xml.Add(new XElement(textBox.ID, textBox.Text));
                        }
                        var checkBox = child as CheckBox;
                        if (checkBox != null)
                        {
                            xml.Add(new XElement(checkBox.ID, checkBox.Checked));
                        }
                    }
                }
            }
            return xml;
        }
    }
}
