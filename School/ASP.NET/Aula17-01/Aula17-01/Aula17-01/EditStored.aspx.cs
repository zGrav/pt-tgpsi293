using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Aula17_01
{
    public partial class EditStored : System.Web.UI.Page {
    
        string getConCfg = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StoreProcClass spc = new StoreProcClass();

            spc.storeEditParamsID("@getID", Convert.ToInt32(TextBox1.Text));

            spc.storeEditParams("@getName", TextBox2.Text);
            spc.storeEditParams("@getEmail", TextBox3.Text);
            spc.storeEditParams("@getUser", TextBox4.Text);
            spc.storeEditParams("@getPass", TextBox5.Text);
            spc.storeEditParams("@getPic", TextBox6.Text);

            spc.EditData(getConCfg);

            Response.Redirect("~/EditStored.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text =GridView1.SelectedRow.Cells[3].Text;
            TextBox4.Text =GridView1.SelectedRow.Cells[4].Text;
            TextBox5.Text =GridView1.SelectedRow.Cells[5].Text;
            TextBox6.Text = GridView1.SelectedRow.Cells[6].Text;
        }
    }
}