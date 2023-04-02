﻿using System;
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
            }
            else if (File.Exists(MapPath("~/Images/Profile/User-" + user.idProperty.ToString()+ ".jpg")))
            {
                ImgArticle.ImageUrl = "./Images/Profile/User-" + user.idProperty.ToString() + ".jpg";
            }
            else
            {
                ImgArticle.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            }
        }
        private void saveImg()
        {
            //prox hacer mas abstracto, en clase helper.
            if (!string.IsNullOrEmpty(TxtUrl.Text) && TxtUrl.Text.Contains("https"))
            {
                File.Delete(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg"));
                user.UrlProfileImage = TxtUrl.Text;
            }
                
            else if (File.Exists(MapPath("~/Images/Profile/User-" + user.idProperty.ToString() + ".jpg")))
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
            saveImg();
            userBusiness.update(user);
            Response.Redirect("FrmDashBoardWithCards.aspx", false);
        }
    }
}