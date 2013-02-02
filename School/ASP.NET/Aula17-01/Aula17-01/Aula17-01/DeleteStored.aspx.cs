using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Aula17_01
{
    public partial class DeleteStored : System.Web.UI.Page
    {
        string getConCfg = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StoreProcClass spc = new StoreProcClass();

            spc.storeDeleteParams("@id", Convert.ToInt32(TextBox1.Text));

            spc.DeleteData(getConCfg);

            Response.Redirect("~/DeleteStored.aspx");
        }
    }
}