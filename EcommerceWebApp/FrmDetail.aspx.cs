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
                chargeControlls();
            }
               
        }
        private void chargeImage()
        {
            if (article.Image.Contains("https"))
            {
                ImgArticle.ImageUrl = article.Image;
            }
            else if (File.Exists(MapPath("~/Images/Articles/Article-" + article.Code + ".jpg")))
            {
                ImgArticle.ImageUrl = "~/Images/Articles/Article-" + article.Code + ".jpg";
            }
            else
                ImgArticle.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
        }
        private void chargeControlls()
        {
            List<Article> articleList = new List<Article>();
            articleList.Add(article);
            FullName.Text = article.Brand + " " + article.Name;
            LblPrice1.Text = "$" + article.Price.ToString();
            chargeImage();
            GvArticle.DataSource = articleList;
            GvArticle.DataBind();
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            Response.Redirect("FrmArticleRegister.aspx?id=" + article.Id);
        }
    }
}