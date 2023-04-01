using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;

namespace EcommerceWebApp
{
    public partial class UserConfig : System.Web.UI.Page
    {
        private static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["activeUser"];
        }
    }
}