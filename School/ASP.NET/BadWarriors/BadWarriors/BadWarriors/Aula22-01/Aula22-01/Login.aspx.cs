using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;

namespace Aula22_01
{
    public partial class Main : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private string returnEncoded;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPwd.Text))
            {
                byte[] pwd = Encoding.UTF8.GetBytes(txtPwd.Text);

                returnEncoded = Convert.ToBase64String(pwd);
            }

            LoginManagement lg = new LoginManagement();

            lg.getLoginParams("@user", txtUsr.Text);
            lg.getLoginParams("@pw", returnEncoded);

            if (lg.doLogin(getCon) == true)
            {

                lg.add50HPParams("@username", txtUsr.Text);
                lg.add50HP(getCon);

                lg.add50MoneyParams("@username", txtUsr.Text);
                lg.add50Money(getCon);

                Session["username"] = txtUsr.Text;
                Response.Redirect("~/Main.aspx");
            }

            else
            {
                Label2.Text = "Error occurred.";
            }

        }
    }
}