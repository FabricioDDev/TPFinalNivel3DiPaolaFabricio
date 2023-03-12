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
    public partial class DashBoardWithCards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                chargeCards();
        }
        private void chargeCards()
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            RptrCards.DataSource = articleBusiness.Listing();
            RptrCards.DataBind();
        }

        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FrmDetail.aspx?id=" + Id);
        }
    }
}