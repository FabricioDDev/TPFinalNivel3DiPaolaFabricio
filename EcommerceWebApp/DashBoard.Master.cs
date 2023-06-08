using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;

namespace EcommerceWebApp
{
    public partial class DashBoard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError.aspx", false);
            if (!Security.isUserActive(Session["activeUser"]))
                Response.Redirect("FrmSignUp.aspx", false);
            
               
            if (!IsPostBack)
            {
                BtnCreate.Visible = Security.isAdmin(Session["activeUser"]) ? true : false; ;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                chargeImgProfile();
            }
                
            
        }
        private void chargeImgProfile()
        {
            try
            {
                User user = (User)Session["activeUser"];
                ImgProfile.ImageUrl = user != null && user.UrlProfileImage != null ? user.UrlProfileImage : "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png";
            }
            catch (Exception ex) { Session.Add("Error", ex.ToString()); }
        }



        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("FrmLogIn.aspx", false);
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("FrmArticleRegister.aspx", false);
            }catch(Exception ex) { Session.Add("Error", ex.ToString()); }
        }
    }
}