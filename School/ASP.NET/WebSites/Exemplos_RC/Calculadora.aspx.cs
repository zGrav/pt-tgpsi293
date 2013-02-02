using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calculadora : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = "~/images/bsod.jpg";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        decimal result = (Convert.ToDecimal(TextBox1.Text) + Convert.ToDecimal(TextBox2.Text) + Convert.ToDecimal(TextBox3.Text)) / 3;
        TextBox4.Text = result.ToString();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
        {
            Image1.ImageUrl = "~/images/bsod.jpg";
        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            Image1.ImageUrl = "~/images/trains.png";
        }
        else if (DropDownList1.SelectedIndex == 2)
        {
            Image1.ImageUrl = "~/images/win8bsod1.png";
        }
    }
}