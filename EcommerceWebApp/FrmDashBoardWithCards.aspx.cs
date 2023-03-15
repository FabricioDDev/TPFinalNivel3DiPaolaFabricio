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
        public DashBoardWithCards()
        {
            articleBusiness = new ArticleBusiness();
            
        }
        public ArticleBusiness articleBusiness;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!IsPostBack)
                chargeCards(articleBusiness.Listing());
            stateCkbxAdvancedFilter();
        }
        private void stateCkbxAdvancedFilter()
        {
            if (CkbxAdvancedFilter.Checked == true)
            {
                LblCamp.Visible = true;
                LblCriterion.Visible = true;
                DdlCamp.Visible = true;
                DdlCriterion.Visible = true;
                BtnApplyFilter.Visible = true;
            }
            else if (CkbxAdvancedFilter.Checked == false)
            {
                LblCamp.Visible = false;
                LblCriterion.Visible = false;
                DdlCamp.Visible = false;
                DdlCriterion.Visible = false;
                BtnApplyFilter.Visible = false;
            }
        }
        private void chargeCards(List<Article>List)
        {
            RptrCards.DataSource = List;
            RptrCards.DataBind();
        }
        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FrmDetail.aspx?id=" + Id);
        }
        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Article>list = articleBusiness.Listing().FindAll(
                x => x.Code.ToUpper().Contains(TxtSearch.Text.ToUpper()) ||
                x.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
            chargeCards(list);
        }

    }
}