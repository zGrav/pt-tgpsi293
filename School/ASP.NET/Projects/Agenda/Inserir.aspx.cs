using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inserir : System.Web.UI.Page
{
    Pessoa p = new Pessoa();
    int val; //passes pbox.selectedindex
    int count; //used to count pbox items

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void insBtn_Click(object sender, EventArgs e)
    {
        
        p.load(nomeTxt.Text, emailTxt.Text, telTxt.Text);
        p.add(p);

        nomeTxt.Text = "";
        emailTxt.Text = "";
        telTxt.Text = "";
        pesLabel.Text = "";
    }

    protected void listBtn_Click(object sender, EventArgs e)
    {

        pBox.Items.Clear();

        foreach (Pessoa px in p.rtn_values()) {
            pBox.Items.Add(px.getName().ToString() + " " + px.getMail().ToString() + " " + px.getPhone().ToString() + "\n");
            count++;
        }
        countLabel.Text = "Count: " + count.ToString();

        pesLabel.Text = "";
    }

    protected void btnApagar_Click(object sender, EventArgs e)
    {
        
        p.delete(pBox.SelectedIndex);

        pBox.Items.Clear();

        foreach (Pessoa px in p.rtn_values())
        {
            pBox.Items.Add(px.getName().ToString() + " " + px.getMail().ToString() + " " + px.getPhone().ToString() + "\n");
            count++;
        }

        countLabel.Text = "Count: " + count.ToString();

        pesLabel.Text = "";
    }

    protected void editBtn_Click(object sender, EventArgs e)
    {
        val = pBox.SelectedIndex;
        nomeTxt.Text = "";
        nomeTxt.Text = p.recval(pBox.SelectedIndex).getName().ToString();
        emailTxt.Text = "";
        emailTxt.Text = p.recval(pBox.SelectedIndex).getMail().ToString();
        telTxt.Text = "";
        telTxt.Text = p.recval(pBox.SelectedIndex).getPhone().ToString();

        pesLabel.Text = "";
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {
        p.saveval(val, nomeTxt.Text, emailTxt.Text, telTxt.Text);

        pBox.Items.Clear();

        foreach (Pessoa px in p.rtn_values())
        {
            pBox.Items.Add(px.getName().ToString() + " " + px.getMail().ToString() + " " + px.getPhone().ToString() + "\n");
            count++;
        }

        countLabel.Text = "Count: " + count.ToString();

        nomeTxt.Text = "";
        emailTxt.Text = "";
        telTxt.Text = "";

        pesLabel.Text = "";
    }
    protected void pesBtn_Click(object sender, EventArgs e)
    {
        pesLabel.Text = p.searchval(pesTxt.Text);
    }

    protected void ordLabel_Click(object sender, EventArgs e)
    {

    }
    protected void ordBtn_Click(object sender, EventArgs e)
    {
        pBox.Items.Clear();

        Pessoa px2 = new Pessoa();

        px2.sortval();

        foreach (Pessoa px in p.rtn_values())
        {
            pBox.Items.Add(px.getName().ToString() + " " + px.getMail().ToString() + " " + px.getPhone().ToString() + "\n");
        }

    }
}   