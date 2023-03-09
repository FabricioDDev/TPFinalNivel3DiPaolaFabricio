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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            User user = new User(false);
            user.EmailProperty = TxtEmail.Text;
            user.PassProperty = TxtPass.Text;
            user.nameProperty= TxtName.Text != ""? TxtName.Text : null;
            user.lastNameProperty= TxtLastName.Text != "" ? TxtLastName.Text :null;
            userBusiness.Insert(user);
        }

        protected void BtnViewPass_Click(object sender, EventArgs e)
        {
            if (TxtPass.TextMode == TextBoxMode.Password)
                TxtPass.TextMode = TextBoxMode.SingleLine;
            else
                TxtPass.TextMode = TextBoxMode.Password;
        }
    }
}