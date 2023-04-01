using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace EcommerceWebApp
{
    public partial class DashBoard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["activeUser"];
            ImgProfile.ImageUrl = user.UrlProfileImage != null? user.UrlProfileImage : "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("FrmLogIn.aspx", false);
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmArticleRegister.aspx", false);
        }
    }
}