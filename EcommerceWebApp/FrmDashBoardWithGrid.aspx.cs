using BusinessModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace EcommerceWebApp
{
    public partial class DashBoardWithGrid : System.Web.UI.Page
    {
        public DashBoardWithGrid() { articleBusiness = new ArticleBusiness(); }
        private ArticleBusiness articleBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chargeCards(articleBusiness.Listing());
                chargeDdlCamp();
            }

            stateCkbxAdvancedFilter();
        }

        protected void GvArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = GvArticles.SelectedDataKey.Value.ToString();
            Response.Redirect("FrmDetail.aspx?Id=" + Id.ToString());
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
                LblSearch.Enabled = false;
                TxtSearch.Enabled = false;
            }
            else if (CkbxAdvancedFilter.Checked == false)
            {
                LblSearch.Enabled = true;
                TxtSearch.Enabled = true;
                LblCamp.Visible = false;
                LblCriterion.Visible = false;
                DdlCamp.Visible = false;
                DdlCriterion.Visible = false;
                BtnApplyFilter.Visible = false;
            }
        }
        private void chargeDdlCamp()
        {
            DdlCamp.Items.Clear();
            DdlCamp.Items.Add("Brand");
            DdlCamp.Items.Add("Price");
            DdlCamp.Items.Add("Category");
        }
        private void chargeCards(List<Article> List)
        {
            GvArticles.DataSource = List;
            GvArticles.DataBind();
        }
        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Article> list = articleBusiness.Listing().FindAll(
                x => x.Code.ToUpper().Contains(TxtSearch.Text.ToUpper()) ||
                x.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
            chargeCards(list);
        }
        protected void DdlCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlCriterion.Items.Clear();
            if (DdlCamp.SelectedValue == "Brand")
            {
                BrandBusiness brandBusiness = new BrandBusiness();
                DdlCriterion.DataSource = brandBusiness.Listing();
                DdlCriterion.DataValueField = "Id";
                DdlCriterion.DataTextField = "Name";
                DdlCriterion.DataBind();
            }
            else if (DdlCamp.SelectedValue == "Price")
            {
                DdlCriterion.Items.Add("- to +");
                DdlCriterion.Items.Add("+ to -");
            }
            else if (DdlCamp.SelectedValue == "Category")
            {
                CategoryBusiness categoryBusiness = new CategoryBusiness();
                DdlCriterion.DataSource = categoryBusiness.Listing();
                DdlCriterion.DataValueField = "Id";
                DdlCriterion.DataTextField = "Name";
                DdlCriterion.DataBind();
            }
        }

        protected void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            string Camp = DdlCamp.SelectedValue;
            string Criterion = DdlCriterion.SelectedValue;
            chargeCards(articleBusiness.listFiltered(Camp, Criterion));
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}