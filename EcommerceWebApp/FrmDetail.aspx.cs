using BusinessModel;
using DomainModel;
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
        public FrmDetail() { }
        public Article article;
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            article = articleBusiness.Listing().Find(x => x.Id == int.Parse(Request.QueryString["id"]));
            if (!IsPostBack)
            {
                chargeDdl();
                chargeControlls();
            }
               
        }
        private void chargeControlls()
        {
            FullName.Text = article.Brand + " " + article.Name;
            TxtCode.Text = article.Code;
            TxtName.Text = article.Name;    
            TxtDescription.Text = article.Description;
            DdlBrand.SelectedValue = article.Brand.Id.ToString();
            DdlCategory.SelectedValue = article.Category.Id.ToString();
            TxtPrice.Text = article.Price.ToString();
        }
        private void chargeDdl()
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            DdlBrand.DataSource= brandBusiness.Listing();
            DdlBrand.DataValueField = "Id";
            DdlBrand.DataTextField = "Name";
            DdlBrand.DataBind();

            CategoryBusiness categoryBusiness = new CategoryBusiness();
            DdlCategory.DataSource= categoryBusiness.Listing();
            DdlCategory.DataValueField = "Id";
            DdlCategory.DataTextField = "Name";
            DdlCategory.DataBind();
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}