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
        private static Article article;
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
            TxtId.Text = article.Id.ToString();
            TxtCode.Text = article.Code;
            TxtName.Text = article.Name;
            TxtPrice.Text = article.PriceStringFormat;
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
            else if (File.Exists(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg")))
            {
                ImgArticle.ImageUrl = "./Images/Articles/Article-" + article.Code + ".jpg";
            }
            else
            {
                ImgArticle.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
        private void saveImg()
        {
            //prox hacer mas abstracto, en clase helper.
            if (!string.IsNullOrEmpty(TxtUrl.Text) && TxtUrl.Text.Contains("https"))
                article.Image = TxtUrl.Text;
            else if (File.Exists(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg")))
            {
                File.Delete(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg"));
                InputFile.PostedFile.SaveAs(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg"));
                article.Image = "./Images/Articles/Article-" + article.Code + ".jpg";
            }
            else
            {
                InputFile.PostedFile.SaveAs(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg"));
                article.Image = "./Images/Articles/Article-" + article.Code + ".jpg";
            }
        }
        private void savesChanges()
        {
            if (article.Id != 0)
            {
                article.Id = int.Parse(TxtId.Text);
                articleBusiness.Update(article);
            }

            else
                articleBusiness.Insert(article);
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            article = article == null? new Article() : article;

            article.Code = TxtCode.Text;
            article.Name= TxtName.Text;
            article.Description= TxtDescription.Text;
            article.Price = decimal.Parse(TxtPrice.Text);
            article.Brand = new Brand();
            article.Brand.Id = int.Parse(DdlBrand.SelectedValue);
            article.Category = new Category();
            article.Category.Id = int.Parse(DdlCategory.SelectedValue);
            saveImg();
            savesChanges();
        }
    }
}