using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.Security.Cryptography.X509Certificates;

namespace EcommerceWebApp
{
    public partial class DashBoard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("FrmLogIn.aspx", false);
        }

    }
}