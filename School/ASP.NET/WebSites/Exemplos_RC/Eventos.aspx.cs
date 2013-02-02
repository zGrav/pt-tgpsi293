using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eventos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = "0";
            TextBox2.Text = "0";
            TextBox3.Text = "0";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (DropDownList1.SelectedIndex == 0)
        {
            TextBox3.Text = Convert.ToString(Convert.ToDecimal(TextBox1.Text) + Convert.ToDecimal(TextBox2.Text));
        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            TextBox3.Text = Convert.ToString(Convert.ToDecimal(TextBox1.Text) - Convert.ToDecimal(TextBox2.Text));
        }
        else if (DropDownList1.SelectedIndex == 2)
        {
            TextBox3.Text = Convert.ToString(Convert.ToDecimal(TextBox1.Text) * Convert.ToDecimal(TextBox2.Text));
        }
        else if (DropDownList1.SelectedIndex == 3)
        {
            TextBox3.Text = Convert.ToString(Convert.ToDecimal(TextBox1.Text) / Convert.ToDecimal(TextBox2.Text));
        }
    }

}