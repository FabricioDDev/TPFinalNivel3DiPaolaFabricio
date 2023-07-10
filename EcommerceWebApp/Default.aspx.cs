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
        private List<TextBox>inputs = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError.aspx", false);
            inputs.Add(TxtEmail);
            inputs.Add(TxtPass);
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            try
            {
                if (!validateControlls())
                    return;
                User user = userBusiness.LogIn(TxtPass.Text, TxtEmail.Text);
                if (user != null)
                {
                    Session.Add("activeUser", user);
                    Response.Redirect("FrmDashBoardWithCards.aspx", false);
                } 
                else
                {
                    LblWarning.Visible = true;
                    LblWarning.Text = "Incorrect User, Try again!";
                }
            }catch(Exception ex)
            {
                Session.Add("Error", ex.Message);
            }
         }
        private bool validateControlls()
        {
            try
            {
                foreach (TextBox txt in inputs)
                {
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        LblWarning.Visible = true;
                        LblWarning.Text = "Oh, Forgot to write your Email or PassWord?";
                        return false;
                    }
                }
                return true;
            }
            catch(Exception ex){ throw ex; }
        }

        protected void LktbtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmSignUp.aspx", false);
        }
    }
}