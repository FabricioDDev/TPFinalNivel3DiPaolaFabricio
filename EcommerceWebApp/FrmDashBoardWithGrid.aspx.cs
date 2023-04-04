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
                chargeGv(articleBusiness.Listing());
                chargeDdlCamp();
                chargeDdlCriterion();
            }

            stateCkbxAdvancedFilter();
        }
        //GvArticles
        private void chargeGv(List<Article> List)
        {
            GvArticles.DataSource = List;
            GvArticles.DataBind();
        }
        protected void GvArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = GvArticles.SelectedDataKey.Value.ToString();
            Response.Redirect("FrmDetail.aspx?Id=" + Id.ToString());
        }
        //Basic Filter
        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Article> list = articleBusiness.Listing().FindAll(
                x => x.Code.ToUpper().Contains(TxtSearch.Text.ToUpper()) ||
                x.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
            chargeGv(list);
        }
        //Advanced Filter
        private void chargeDdlCriterion()
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
        private void chargeDdlCamp()
        {
            DdlCamp.Items.Clear();
            DdlCamp.Items.Add("Brand");
            DdlCamp.Items.Add("Price");
            DdlCamp.Items.Add("Category");
            DdlCamp.SelectedIndex = 0;
        }
        private void stateCkbxAdvancedFilter()
        {
            if (CkbxAdvancedFilter.Checked == true)
            {
                visibleGroupControllsFilter(true);
            }
            else if (CkbxAdvancedFilter.Checked == false)
            {
                chargeGv(articleBusiness.Listing());
                visibleGroupControllsFilter(false);
            }
        }
        private void visibleGroupControllsFilter(bool visible)
        {
            LblSearch.Enabled = !visible ? true : false;
            TxtSearch.Enabled = !visible ? true : false;
            LblCamp.Visible = visible;
            LblCriterion.Visible = visible;
            DdlCamp.Visible = visible;
            DdlCriterion.Visible = visible;
            BtnApplyFilter.Visible = visible;
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
            List<Article> articles;
            string Camp = DdlCamp.SelectedValue;
            string Criterion = DdlCriterion.SelectedValue;

            if (Criterion == "- to +")
                articles = articleBusiness.Listing().OrderBy(x => x.Price).Reverse().ToList();
            else if (Criterion == "+ to -")
                articles = articleBusiness.Listing().OrderBy(x => x.Price).ToList();
            else
                articles = articleBusiness.listFiltered(Camp, Criterion);

            chargeGv(articles);
        }
        //
        protected void BtnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}