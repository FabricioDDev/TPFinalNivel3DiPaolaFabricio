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
            user = (User)Session["activeUser"];
            ListingArticleFavorites();
            RptrFavorites.DataSource= articles;
            RptrFavorites.DataBind();
            ListingArticleFavorites();
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
    }
}