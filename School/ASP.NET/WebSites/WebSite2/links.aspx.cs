using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class links : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 0)
        {
            Response.Redirect("Calculadora.aspx");
        }

        else if (DropDownList1.SelectedIndex == 1)
        {
            Response.Redirect("Default.aspx");
        }

        else if (DropDownList1.SelectedIndex == 2)
        {
            Response.Redirect("Sobre.aspx");
        }

        else if (DropDownList1.SelectedIndex == 3)
        {
            Response.Redirect("Produtos.aspx");
        }
    }
}