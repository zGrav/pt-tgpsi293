using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Aula17_01
{
    public partial class NormalInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string getConCfg = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(getConCfg);
            SqlCommand cmd = new SqlCommand("INSERT INTO aluno (name, email, username, pass, pic) VALUES ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','~/images/" + TextBox5.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/NormalInsert.aspx");
        }
    }
}