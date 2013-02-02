using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;

namespace Aula22_01
{
    public partial class Register : System.Web.UI.Page
    {
        private string getCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private string returnEncoded;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtPwd.Text))
            {
                byte[] pwd = Encoding.UTF8.GetBytes(txtPwd.Text);

                returnEncoded = Convert.ToBase64String(pwd);
            }

            LoginManagement lg = new LoginManagement();

            lg.getRegisterParams("@user", txtUsr.Text);
            lg.getRegisterParams("@pw", returnEncoded);
            lg.getRegisterParams("@email", txtEmail.Text);

            if (lg.doRegister(getCon) == true)
            {
                Label4.Text = "Register successful. Redirecting to Login in 3 seconds.";
                Thread.Sleep(3000);
                Response.Redirect("~/Login.aspx");
            }

            else
            {
                Label4.Text = "Error occurred.";
            }
        }
    }
}