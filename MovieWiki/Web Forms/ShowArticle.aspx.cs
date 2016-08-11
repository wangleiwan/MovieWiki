using MovieWiki.Custom_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MovieWiki.Web_Forms
{
    public partial class ShowArticle : System.Web.UI.Page
    {
        private Article _article;
        private const string Edit = "Edit";
        private const string Save = "Save";

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("SearchArticle.aspx");
            }
            else
            {
                GetAndDisplayArticleControls(Convert.ToInt32(id));
            }
        }

        private void GetAndDisplayArticleControls(int id)
        {
            _article = MovieWikiDbHelper.GetWikiArticleById(id);
            if (_article == null) return;
            var articleControls = _article.BuildControls();

            foreach (var row in articleControls)
            {
                pnlArticleContent.Controls.Add(row);
            }

            var titleControl = FindControl("Title") as TextBox;
            titleControl.Enabled = false;
            if (MovieWikiDbHelper.IsUserAdmin((Session[Global.ActiveUserAccount] as UserAccount).Username))
            {
                btnDeleteArticle.Visible = true;
            }
            ToggleControls(pnlArticleContent);
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            ToggleEditSaveButtonText();
        }

        private void ToggleEditSaveButtonText()
        {
            if (btnEditSave.Text == Edit)
            {
                btnEditSave.Text = Save;
            }
            else
            {
                UpdateEdits();
                btnEditSave.Text = Edit;
            }
        }

        private void UpdateEdits()
        {
            var xml = _article.ComposeXml(pnlArticleContent);
            // NB editor does not always equal article author (the original author that created the article)
            var editor = Session[Global.ActiveUserAccount] as UserAccount;
            var timestamp = DateTime.Now;

            if (MovieWikiDbHelper.UpdateWikiArticle(_article.ArticleId, xml.ToString()))
            {
                MovieWikiDbHelper.InsertWikiArticleEditHistory(_article.ArticleId, editor.AccountId, timestamp);
                // TODO is this session variable necessary?
                Session[Global.ActiveArticle] = _article;
            }
            else
            {
                Response.Write("An error occured while updating the article");
            }
        }

        private void ToggleControls(Control c)
        {
            if (c.HasControls())
            {
                foreach (Control control in c.Controls)
                {
                    ToggleControls(control);
                }
            }
            else
            {
                if (c.ID != "Title")  // Don't let the Title be changeable
                {
                    var textBox = c as TextBox;
                    if (textBox != null)  
                    {
                        textBox.Enabled = !textBox.Enabled;
                    }
                    var checkBox = c as CheckBox;
                    if (checkBox != null)
                    {
                        checkBox.Enabled = !checkBox.Enabled;
                    }
                }
            }
        }

        // for user "admin" only
        protected void btnDeleteArticle_Click(object sender, EventArgs e)
        {
            if (!DeleteArticle())
            {
                Response.Write("Error deleting article");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private bool DeleteArticle()
        {
            return MovieWikiDbHelper.DeleteWikiArticle(_article.ArticleId);
        }

        //navbar button event
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session[Global.ActiveUserAccount] = null;
            Response.Redirect("Default.aspx");
        }

        protected void btnsearchbtn_Click(object sender, EventArgs e)
        {
            var searchResultUrl = MovieWikiDbHelper.GetWikiArticleUrlBySearch(searchInput.Text);
            if (searchResultUrl != null)
            {
                Response.Redirect(searchResultUrl);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }


        }
    }
}