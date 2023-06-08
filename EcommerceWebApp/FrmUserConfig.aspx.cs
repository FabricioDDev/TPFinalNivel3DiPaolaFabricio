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
            if (!IsPostBack && Session["activeUser"] != null)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                user = (User)Session["activeUser"];
                chargeControlls();
            }
            else
                Response.Redirect("FrmSignUp.aspx", false);
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
                ImgProfile.ImageUrl = user.UrlProfileImage;
                TxtUrl.Text = user.UrlProfileImage;
            }
            else if (File.Exists(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg")))
            {
                ImgProfile.ImageUrl = "./Images/Profile/User-" + user.idProperty.ToString() + ".jpg";
            }
            else
            {
                ImgProfile.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            }
        }
        private void saveLocalImg()
        {
            if (File.Exists(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg")))
            {
                File.Delete(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg"));
                InputFile.PostedFile.SaveAs(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg"));
                user.UrlProfileImage = "./Images/Profile/User-" + user.idProperty.ToString() + ".jpg";
            }
            else
            {
                InputFile.PostedFile.SaveAs(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg"));
                user.UrlProfileImage = "./Images/Profile/User-" + user.idProperty.ToString() + ".jpg";
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            user.PassProperty = TxtPassword.Text;
            user.nameProperty = string.IsNullOrEmpty(TxtName.Text) ? null : TxtName.Text;
            user.lastNameProperty = string.IsNullOrEmpty(TxtLastName.Text) ? null : TxtLastName.Text;

            if (!string.IsNullOrEmpty(TxtUrl.Text) && TxtUrl.Text.Contains("https"))
            {
                File.Delete(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg"));
                user.UrlProfileImage = TxtUrl.Text;
            }
            else
                saveLocalImg();
            userBusiness.update(user);
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}