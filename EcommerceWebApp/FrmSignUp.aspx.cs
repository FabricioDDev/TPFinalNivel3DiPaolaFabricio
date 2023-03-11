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
    public partial class FrmSignUp : System.Web.UI.Page
    {
        private List<TextBox> inputs = new List<TextBox>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Security.isErrorSessionActive(Session["Error"]))
                Response.Redirect("FrmError");

            if (!IsPostBack)
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
            }
            catch (Exception ex)
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
                    if ((txt.ID == "TxtEmail" || txt.ID == "TxtPass") && string.IsNullOrEmpty(txt.Text))
                    {
                        LblWarning.Visible = true; 
                        LblWarning.Text = "Oh, The Email and Password are required!";
                        return false;
                    }

                    if (!(string.IsNullOrEmpty(txt.Text)) && !Helper.validatingTxtLong(txt.Text, 5, 30))
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