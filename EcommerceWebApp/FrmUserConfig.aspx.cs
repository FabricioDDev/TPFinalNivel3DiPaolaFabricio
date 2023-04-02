using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.IO;

namespace EcommerceWebApp
{
    public partial class UserConfig : System.Web.UI.Page
    {
        private static User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["activeUser"];
            if (!IsPostBack)
            {
                chargeControlls();
            }
        }
        private void chargeControlls()
        {
            TxtEmail.Text = user.EmailProperty;
            TxtPassword.Text = user.PassProperty;
            TxtName.Text = user.nameProperty;
            TxtLastName.Text = user.lastNameProperty;
            chargeImage();
        }
        private void chargeImage()
        {
            if (user.UrlProfileImage.Contains("https"))
            {
                ImgArticle.ImageUrl = user.UrlProfileImage;
                TxtUrl.Text = user.UrlProfileImage;
            }
            else if (File.Exists(MapPath("~/Images/Articles/Article-" + user.idProperty.ToString()+ ".jpg")))
            {
                ImgArticle.ImageUrl = "./Images/Articles/Article-" + user.idProperty.ToString() + ".jpg";
            }
            else
            {
                ImgArticle.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            }
        }
    }
}