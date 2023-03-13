using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;

namespace EcommerceWebApp
{
    public partial class DashBoard : System.Web.UI.MasterPage
    {
        public DashBoard()
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            ArticleList = articleBusiness.Listing();

        }
        //Hacer atributo lista desde la master, y consumirla desde las paginas hijas.
        public static List<Article> ArticleList;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("FrmLogIn.aspx", false);
        }
    }
}