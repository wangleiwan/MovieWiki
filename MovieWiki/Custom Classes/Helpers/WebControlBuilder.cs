using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
    public class WebControlBuilder
    {
        public static Tuple<Label, TextBox> BuildLabelTextBoxPair(string labelId, string labelText, string textBoxId,
            TextBoxMode txtBoxMode = TextBoxMode.SingleLine, int colSpan = 25, int rowSpan = 1)
        {
            var label = new Label();
            label.Text = labelText;
            label.ID = labelId;
            var textBox = new TextBox();
            textBox.ID = textBoxId;
            //textBox.TextMode = txtBoxMode;
            //textBox.Columns = colSpan;
            //textBox.Rows = rowSpan;
            textBox.CssClass = "form-control";

            return new Tuple<Label, TextBox>(label, textBox);
        }

        public static Tuple<Label, CheckBox> BuildLabelCheckBoxPair(string labelId, string labelText, string checkBoxId)
        {
            var label = new Label();
            label.Text = labelText;
            label.ID = labelId;
            var checkBox = new CheckBox();
            checkBox.ID = checkBoxId;
            return new Tuple<Label, CheckBox>(label, checkBox);
        }

        public static TableRow BuildTableRow(Control key, Control value)
        {
            var tableCellKey = new TableCell();
            var tableCellValue = new TableCell();
            tableCellKey.Controls.Add(key);
            tableCellValue.Controls.Add(value);
            var tableRow = new TableRow();
            tableRow.Controls.Add(tableCellKey);
            tableRow.Controls.Add(tableCellValue);
            return tableRow;
        }
    }
}