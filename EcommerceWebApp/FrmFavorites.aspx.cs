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
        //<script> window.open('" + pageurl + "','_blank'); </script>
        private List<Article> articles= new List<Article>();
        private FavoriteBusiness favoriteBusiness;
        private ArticleBusiness articleBusiness;
        private static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                user = (User)Session["activeUser"];
                ListingArticleFavorites();
                chargeRptrFavorites();
            }
        }
        public void chargeRptrFavorites()
        {
            RptrFavorites.DataSource = articles;
            RptrFavorites.DataBind();
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
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FrmDetail.aspx?id=" + Id);
        }
    }
}