using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public static class WebControlBuilder
    {
        // Noe
        // Changed from tablerows all changed panel
        // Textbox is in panel can be changed to just texbox but needs to have panel at some place
        // for how peter expects it to work
        public static Tuple<Label, Panel> BuildLabelTextBoxPair(string labelId, string labelText, string textBoxId,
            string textBoxContent = null, TextBoxMode txtBoxMode = TextBoxMode.SingleLine, int colSpan = 25, int rowSpan = 1)
        {
            var label = new Label();
            label.Text = labelText;
            label.CssClass = "col-sm-2 control-label";
            label.ID = labelId;

            Panel panel = new Panel();
            panel.CssClass = "col-sm-10";
            
            var textBox = new TextBox();
            textBox.ID = textBoxId;
            textBox.TextMode = txtBoxMode;
            textBox.Columns = colSpan;
            textBox.Rows = rowSpan;
            textBox.Text = textBoxContent;
            textBox.CssClass = "form-control";
            panel.Controls.Add(textBox);

            return new Tuple<Label, Panel>(label, panel);
        }

        public static Tuple<Label, CheckBox> BuildLabelCheckBoxPair(string labelId, string labelText, 
            string checkBoxId, bool isChecked = false)
        {
            var label = new Label();
            label.Text = labelText;
            label.ID = labelId;
            var checkBox = new CheckBox();
            checkBox.ID = checkBoxId;
            checkBox.Checked = isChecked;
            return new Tuple<Label, CheckBox>(label, checkBox);
        }

        public static Panel BuildPanel(params Control[] controls)
        {
            var panel = new Panel();
            panel.CssClass = "form-group";
            foreach (var control in controls)
            {
                panel.Controls.Add(control);
            }
            return panel;
        }

        public static HyperLink BuildHyperLink(string text, string url)
        {
            var hyperLink = new HyperLink();
            hyperLink.Text = text;
            hyperLink.NavigateUrl = url;
            return hyperLink;
        }

        public static RequiredFieldValidator BuildReqFieldValidator(string ctrlToVldate, string Id, string errorMsg)
        {
            return new RequiredFieldValidator
            {
                ControlToValidate = ctrlToVldate,
                ValidationGroup = "vldArticleTemplateControls",
                ID = Id,
                ErrorMessage = errorMsg,
                ForeColor = Color.Red
            };
        }
    }
}