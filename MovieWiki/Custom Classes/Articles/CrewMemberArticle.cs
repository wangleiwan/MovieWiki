using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace MovieWiki.Custom_Classes
{
    public class CrewMemberArticle : PersonArticle
    {
        private RoleSectionFactory _roleSectionFactory = new RoleSectionFactory();
        public List<RoleSection> Roles { get; set; }

        public CrewMemberArticle()
        {
            Roles = new List<RoleSection>();
        }

        public CrewMemberArticle(string[] roles) : this()
        {
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    Roles.Add(_roleSectionFactory.GetInstance(role));
                }
            }
        }

        public CrewMemberArticle(int articleId, int author, string title, string descriptionXml) : this()
        {
            ArticleId = articleId;
            Author = author;
            Title = title;
            var parsedXml = XElement.Parse(descriptionXml);
        }

        public override void ParseData(string articleData)
        {
            base.ParseData(articleData);
            var xml = XElement.Parse(articleData);
            var roleSections = xml.Elements("RoleSections").FirstOrDefault();

            foreach (var role in roleSections.Elements())
            {
                var r = _roleSectionFactory.GetInstance(role.Name.LocalName, role.Value);
                Roles.Add(r);
            }
        }

        public override List<TableRow> BuildControls(string[] parameters)
        {
            var baseRows = base.BuildControls(null);
            var crewMemberRows = new List<TableRow>();
            Roles.ForEach(r => crewMemberRows.AddRange(r.BuildControls()));

            // Insert all before the last description textarea
            baseRows.InsertRange(baseRows.Count - 1, crewMemberRows);

            return baseRows;
        }

        public override XElement ComposeXml(Control table)
        {
            var xml = new XElement(this.GetType().Name);
            var xmlRoleSections = new XElement("RoleSections");

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
                            var xElement = new XElement(textBox.ID, textBox.Text);
                            if (textBox.ID.Contains("Section"))
                            {
                                xmlRoleSections.Add(xElement);
                            }
                            else 
                            {
                                xml.Add(xElement);
                            }
                            
                        }
                        var checkBox = child as CheckBox;
                        if (checkBox != null)
                        {
                            xml.Add(new XElement(checkBox.ID, checkBox.Checked));
                        }
                    }
                }
            }
            xml.Add(xmlRoleSections);
            return xml;
        }

        public override string ToString()
        {
            return "Crew Member Article";
        }
    }
}