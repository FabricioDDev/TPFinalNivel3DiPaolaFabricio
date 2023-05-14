using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebApp
{
    public partial class Profile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError.aspx", false);
            if (!Security.isUserActive(Session["activeUser"]))
                Response.Redirect("FrmSignUp.aspx", false);
        }

        protected void BtnDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }

        protected void BtnFavorites_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmFavorites.aspx", false);
        }

        protected void BtnConfig_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmUserConfig.aspx", false);
        }
    }
}