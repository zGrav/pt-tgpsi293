using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Aula17_01
{
    public partial class StoredProcedure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string getConCfg = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            StoreProcClass spc = new StoreProcClass();

            spc.storeInsertParams("@name", TextBox1.Text);
            spc.storeInsertParams("@email", TextBox2.Text);
            spc.storeInsertParams("@username", TextBox3.Text);
            spc.storeInsertParams("@pass", TextBox4.Text);
            spc.storeInsertParams("@pic", "~/images/" + TextBox2.Text);

            spc.InsertData(getConCfg);

            Response.Redirect("~/StoredProcedure.aspx");
        }
    }
}