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
        public static Article article;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError.aspx", false);
            if (!Security.isUserActive(Session["activeUser"]))
                Response.Redirect("FrmSignUp.aspx", false);
            if (!IsPostBack)
            {
                BtnUpdate.Visible = Security.isAdmin(Session["activeUser"])?true:false;
                ArticleBusiness articleBusiness = new ArticleBusiness();
                article = Request.QueryString["id"] != null?articleBusiness.Listing().Find(x => x.Id == int.Parse(Request.QueryString["id"])) : null;
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
                ImgArticle.ImageUrl = article.Image;
            }
            else
                ImgArticle.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
        }
        private void chargeControlls()
        {
            List<Article> articleList = new List<Article> { article};
            try
            {
                if(article != null)
                {
                    FullName.Text = article.Brand + " " + article.Name;
                    LblPrice1.Text = "$" + article.PriceStringFormat;
                    chargeImage();
                    chargeGv(articleList);
                }
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        private void chargeGv(List<Article>list)
        {
            try
            {
                GvArticle.DataSource = list;
                GvArticle.DataBind();
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
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