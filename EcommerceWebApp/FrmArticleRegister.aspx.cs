using BusinessModel;
using DomainModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcommerceWebApp
{
    public partial class FrmArticleRegister : System.Web.UI.Page
    {
        public FrmArticleRegister()
        {
            articleBusiness = new ArticleBusiness();
        }
        public Article article = null;
        private ArticleBusiness articleBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                chargeDdl();
                if (Request.QueryString["id"] != null)
                {
                    article = articleBusiness.Listing().Find(x => x.Id == int.Parse(Request.QueryString["id"]));
                    chargeControlls();
                }
            }
        }
        private void chargeControlls()
        {
            TxtCode.Text = article.Code;
            TxtName.Text = article.Name;
            TxtDescription.Text = article.Description;
            DdlBrand.SelectedValue = article.Brand.Id.ToString();
            DdlCategory.SelectedValue = article.Category.Id.ToString();
            chargeImage();
        }
        private void chargeDdl()
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            DdlBrand.DataSource = brandBusiness.Listing();
            DdlBrand.DataValueField = "Id";
            DdlBrand.DataTextField = "Name";
            DdlBrand.DataBind();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            DdlCategory.DataSource = categoryBusiness.Listing();
            DdlCategory.DataValueField = "Id";
            DdlCategory.DataTextField = "Name";
            DdlCategory.DataBind();
        }
        private void chargeImage()
        {
            if (article.Image.Contains("https"))
            {
                ImgArticle.ImageUrl = article.Image;
                TxtUrl.Text = article.Image;
            }
            else if (File.Exists(MapPath("~/Images/Articles/Article-" + article.Id + ".jpg")))
            {
                ImgArticle.ImageUrl = "~/Images/Articles/Article-" + article.Id + ".jpg";
            }
            else
            {
                ImgArticle.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            }
        }
    }
}