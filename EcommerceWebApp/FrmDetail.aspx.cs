using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebApp
{
    public partial class FrmDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string IdArticle = Request.QueryString["id"];
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}