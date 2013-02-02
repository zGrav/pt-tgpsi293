using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int parsed, parsed2, result;

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                
                if ((int.TryParse(textBox1.Text, out parsed)) && (int.TryParse(textBox2.Text, out parsed2)))
                {
                    result = parsed + parsed2;
                    textBox3.Text = Convert.ToString(result);
                    
                }

                else
                {
                    MessageBox.Show("Invalid integer in a field.");
                }

            }
                catch (Exception) {
                    MessageBox.Show("Error.");
                }
        }
    }   
}
