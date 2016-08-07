using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MovieWiki.Custom_Classes
{
   
    public abstract class RoleSection
    {
        public string Description { get; set; }

        public abstract List<Panel> BuildControls(string content);
    }
}
