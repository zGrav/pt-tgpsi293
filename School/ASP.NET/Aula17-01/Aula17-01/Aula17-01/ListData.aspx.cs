using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Aula17_01
{
    public partial class ListData : System.Web.UI.Page
    {
        string getConCfg = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        StoreProcClass spc = new StoreProcClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView1.DataSource = spc.ListData(getConCfg).DefaultView;
            //GridView1.DataBind();
                
            if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "No data to display.";
            }
        }
    }
}