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
    public partial class FrmLogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            if (string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtPass.Text))
                return;
            User user = userBusiness.LogIn(TxtPass.Text, TxtEmail.Text);
            if(user != null )
                Session.Add("activeUser", user);
         }

        protected void LktbtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSignUp.aspx", false);
        }
    }
}