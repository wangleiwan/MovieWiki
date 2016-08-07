using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieWiki.Custom_Classes;

namespace MovieWiki.Web_Forms
{
    public partial class ChooseArticleToCreate : System.Web.UI.Page
    {
        private string _queryString = "?articleType=";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Global.ActiveUserAccount] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                SetChildArticlesInvisible();
            }
        }

        protected void rbPersonArticle_CheckedChanged(object sender, EventArgs e)
        {
            personArticleTypes.Visible = true;
            if (rbPersonCrewMemberArticle.Checked)
            {
                personCrewMemberRoles.Visible = true;
            }
        }

        protected void rbMovieArticle_CheckedChanged(object sender, EventArgs e)
        {
            SetChildArticlesInvisible();
        }

        protected void rbPersonCrewMemberArticle_CheckedChanged(object sender, EventArgs e)
        {
            personCrewMemberRoles.Visible = true;
        }

        protected void rbPersonCharacterArticle_CheckedChanged(object sender, EventArgs e)
        {
            personCrewMemberRoles.Visible = false;
        }

        protected void rbPropArticle_CheckedChanged(object sender, EventArgs e)
        {
            SetChildArticlesInvisible();
        }

        private void SetChildArticlesInvisible()
        {
            personArticleTypes.Visible = false;
            personCrewMemberRoles.Visible = false;
        }

        protected void btnCreateTemplate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            // Not sure if there is a better way to do this besides hardcoding it
            if (rbMovieArticle.Checked)
            {
                _queryString += typeof(MovieArticle).Name;
            }
            else if (rbPropArticle.Checked)
            {
                _queryString += typeof(PropArticle).Name;
            }
            else if (rbPersonArticle.Checked)
            {
                if (rbPersonCrewMemberArticle.Checked)
                {
                    _queryString += typeof(CrewMemberArticle).Name;

                    var sectionParams = "&parameters=";
                    if (chbActor.Checked) sectionParams += string.Format("{0},", typeof(ActorSection).Name);
                    if (chbProducer.Checked) sectionParams += string.Format("{0},", typeof(ProducerSection).Name);
                    if (chbDirector.Checked) sectionParams += string.Format("{0},", typeof(DirectorSection).Name);

                    _queryString += sectionParams;
                }
                else if (rbPersonCharacterArticle.Checked)
                {
                    _queryString += typeof(CharacterArticle).Name;
                }
            }
            Response.Redirect("FillArticleContents.aspx" + _queryString);
        }

        protected void vldArticle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // At least one parent radio checked
            if (!rbPersonArticle.Checked
                && !rbMovieArticle.Checked
                && !rbPropArticle.Checked)
            {
                vldArticle.ErrorMessage = "Select either a person, movie, or prop article";
                args.IsValid = false;
            }

            // At least one child radio checked
            if (rbPersonArticle.Checked
                && !rbPersonCharacterArticle.Checked
                && !rbPersonCrewMemberArticle.Checked)
            {
                vldArticle.ErrorMessage = "Select either a character or crew member article type";
                args.IsValid = false;
            }
        }
    }
}