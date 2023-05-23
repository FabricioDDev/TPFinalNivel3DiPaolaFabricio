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
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError.aspx", false);
            if (!Security.isUserActive(Session["activeUser"]))
                Response.Redirect("FrmSignUp.aspx", false);
            if (!Security.isAdmin(Session["activeUser"]))
                Response.Redirect("FrmError.aspx", false);
            if (!IsPostBack)
            {
                chargeDdl();
                if (Request.QueryString["id"] != null)
                {
                    chargeArticle(articleBusiness.Listing());
                    chargeControlls();
                }
            }
        }
        //charge Ddl
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
        //charge article selected
        private void chargeArticle(List<Article> articles)
        {
            try
            {
                article = articles.Find(x => x.Id == int.Parse(Request.QueryString["id"]));
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        private void chargeControlls()
        {
            BtnDelete.Visible = true;
            TxtId.Text = article.Id.ToString();
            TxtCode.Text = article.Code;
            TxtName.Text = article.Name;
            TxtPrice.Text = article.PriceStringFormat;
            TxtDescription.Text = article.Description;
            DdlBrand.SelectedValue = article.Brand.Id.ToString();
            DdlCategory.SelectedValue = article.Category.Id.ToString();
            chargeImage();
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
        private void saveLocalImg()
        {
            if (File.Exists(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg")))
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
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            article = article == null ? new Article() : article;

            article.Code = TxtCode.Text;
            article.Name = TxtName.Text;
            article.Description = TxtDescription.Text;
            article.Price = decimal.Parse(TxtPrice.Text);
            article.Brand = new Brand();
            article.Brand.Id = int.Parse(DdlBrand.SelectedValue);
            article.Category = new Category();
            article.Category.Id = int.Parse(DdlCategory.SelectedValue);
            if (!String.IsNullOrEmpty(TxtUrl.Text))
            {
                article.Image = TxtUrl.Text;
                File.Delete(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg"));
            }
            else
                saveLocalImg();
            savesChanges();
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
        //
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (BtnConfirmDelete.Visible == false)
            {
                LblConfirmDelete.Visible = true;
                BtnConfirmDelete.Visible = true;
            }
        }

        protected void BtnConfirmDelete_Click(object sender, EventArgs e)
        {
            articleBusiness.Delete(article.Id);
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}