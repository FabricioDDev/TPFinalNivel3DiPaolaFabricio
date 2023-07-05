using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using BusinessModel;
using static System.Net.Mime.MediaTypeNames;

namespace EcommerceWebApp
{
    public partial class FrmSignUp : System.Web.UI.Page
    {
        private static List<TextBox> inputs = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError");

            if(!IsPostBack)
                chargeControlls();
        }
        private void chargeControlls()
        {
            inputs.Add(TxtEmail);
            inputs.Add(TxtPass);
            inputs.Add(TxtName);
            inputs.Add(TxtLastName);
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            
            UserBusiness userBusiness = new UserBusiness();
            try
            {
                if (!validateControlls())
                    return;

                User user = new User(false);
                user.EmailProperty = TxtEmail.Text;
                user.PassProperty = TxtPass.Text;
                user.nameProperty = TxtName.Text != "" ? TxtName.Text : null;
                user.lastNameProperty = TxtLastName.Text != "" ? TxtLastName.Text : null;
                userBusiness.Insert(user);
                Session.Add("userActive", user);
                Response.Redirect("FrmDashBoardWithCards.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
            }
        }
        private bool validateControlls()
        {
            UserBusiness userBusiness = new UserBusiness();

            if (string.IsNullOrEmpty(TxtEmail.Text))
            {
                LblWarning.Visible = true;
                LblWarning.Text = "Oh, The Email is required!";
                return false;
            }

            if (string.IsNullOrEmpty(TxtPass.Text))
            {
                LblWarning.Visible = true;
                LblWarning.Text = "Oh, The Password is required!";
                return false;
            }
            if (userBusiness.existUser(TxtEmail.Text))
            {
                LblWarning.Visible = true;
                LblWarning.Text = "There is already an account associated with that email. Try again...";
                return false;
            }
            try
            {
                foreach (TextBox txt in inputs)
                {
                    String textinput = txt.Text;
                    if (txt != null && string.IsNullOrEmpty(textinput) && !Helper.validatingTxtLong(textinput, 5, 30))
                    {
                        LblWarning.Visible = true;
                        LblWarning.Text = "Oh, the camp should have between 5 and 30 characters. Try again!...";
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
        protected void BtnViewPass_Click(object sender, EventArgs e)
        {
            if (TxtPass.TextMode == TextBoxMode.Password)
                TxtPass.TextMode = TextBoxMode.SingleLine;
            else
                TxtPass.TextMode = TextBoxMode.Password;
        }

        protected void LkbtnLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogIn.aspx", false);
        }
    }
}