using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.Drawing;

namespace EcommerceWebApp
{
    public partial class DashBoardWithCards : System.Web.UI.Page
    {
        public DashBoardWithCards()
        {
            articleBusiness = new ArticleBusiness();
            
        }
        public ArticleBusiness articleBusiness;
        public static int IdUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
               
                BtnChangeView.Visible = Security.isAdmin(Session["activeUser"]) ? true : false;
                chargeCards(articleBusiness.Listing());
                chargeDdlCamp();
                chargeDdlCriterion();
                IdUser = Security.isUserActive(Session["activeUser"])? ((User)Session["activeUser"]).idProperty : 0;
            }
            stateCkbxAdvancedFilter();
        }
        //Cards
        private void chargeCards(List<Article> List)
        {
            try
            {
                RptrCards.DataSource = List;
                RptrCards.DataBind();
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FrmDetail.aspx?id=" + Id);
        }
        protected void BtnFavorites_Click(object sender, EventArgs e)
        {
            FavoriteBusiness favoriteBusiness = new FavoriteBusiness();
            string Id = ((Button)sender).CommandArgument;
            favoriteBusiness.insertFavorite(IdUser, int.Parse(Id));
        }
        //Basic Filter
        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Article> list = articleBusiness.Listing().FindAll(
                x => x.Code.ToUpper().Contains(TxtSearch.Text.ToUpper()) ||
                x.Name.ToUpper().Contains(TxtSearch.Text.ToUpper()));
                chargeCards(list);
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        //Advanced Filter
        private void chargeDdlCamp()
        {
            DdlCamp.Items.Clear();
            DdlCamp.Items.Add("Brand");
            DdlCamp.Items.Add("Price");
            DdlCamp.Items.Add("Category");
            DdlCamp.SelectedIndex = 0;
        }
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
        private void stateCkbxAdvancedFilter()
        {
            if (CkbxAdvancedFilter.Checked == true)
            {
                visibleGroupControllsFilter(true);
            }
            else if (CkbxAdvancedFilter.Checked == false)
            {
                chargeCards(articleBusiness.Listing());
                visibleGroupControllsFilter(false);
            }
        }
        private void visibleGroupControllsFilter(bool visible)
        {
            LblSearch.Enabled = !visible? true : false;
            TxtSearch.Enabled = !visible ? true : false;
            LblCamp.Visible = visible;
            LblCriterion.Visible = visible;
            DdlCamp.Visible = visible;
            DdlCriterion.Visible = visible;
            BtnApplyFilter.Visible = visible;
        }
        protected void DdlCamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            chargeDdlCriterion();
        }
        protected void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            List<Article> articles;
            string Camp = DdlCamp.SelectedValue;
            string Criterion = DdlCriterion.SelectedValue;

            if(Criterion == "- to +")
                articles = articleBusiness.Listing().OrderBy(x => x.Price).ToList();
            else if(Criterion == "+ to -")
                articles = articleBusiness.Listing().OrderBy(x => x.Price).Reverse().ToList();
            else
                articles = articleBusiness.listFiltered(Camp, Criterion);

            chargeCards(articles);
        }
        //
        protected void BtnChangeView_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithGrid.aspx", false);
        }
    }
}