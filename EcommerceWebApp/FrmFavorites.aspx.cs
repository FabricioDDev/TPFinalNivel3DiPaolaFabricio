using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.Threading;

namespace EcommerceWebApp
{
    public partial class FrmFavorites : System.Web.UI.Page
    {
        public FrmFavorites()
        {
            favoriteBusiness = new FavoriteBusiness();
            articleBusiness = new ArticleBusiness();
        }
        private List<Article> articles= new List<Article>();
        private FavoriteBusiness favoriteBusiness;
        private ArticleBusiness articleBusiness;
        private static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                user = Session["activeUser"] != null? (User)Session["activeUser"] : null;
                ListingArticleFavorites();
                chargeRptrFavorites();
            }
        }
        public void chargeRptrFavorites()
        {
            try
            {
                RptrFavorites.DataSource = articles;
                RptrFavorites.DataBind();
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
        public void ListingArticleFavorites()
        {
            foreach(Article article in articleBusiness.Listing())
            {
                foreach(Favorites fav in favoriteBusiness.Listing(user.idProperty))
                {
                    if(fav.IdArticle == article.Id) { articles.Add(article); }
                }
            }
        }

        protected void BtnDetail_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = ((Button)sender).CommandArgument;
                Response.Redirect("FrmDetail.aspx?id=" + Id);
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }

        protected void BtnDeleteFavorite_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = ((Button)sender).CommandArgument;
                favoriteBusiness.deleteFavorite(int.Parse(Id), user.idProperty);
                ListingArticleFavorites();
                chargeRptrFavorites();
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }

        protected void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                favoriteBusiness.deleteAllFavorites(user.idProperty);
                RptrFavorites.Visible = false;
                LblEmpty.Visible = true;
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
    }
}