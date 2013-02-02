using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double result = 0; // total/result
        double total1, total2; // operands
        string getop; // handles operations
        //bool reclick;

        void clickHandler(object sender, EventArgs e) // handles button events
        {
            Button button = sender as Button;

            if (screentxt.Text == "0")
            {
                if (getop == null)
                {
                    screentxt.Clear();
                }
            }

            switch ((sender as Button).Name)
            {
                case "btn0": screentxt.Text += "0";
                    break;

                case "btn1": screentxt.Text += "1";
                    break;

                case "btn2": screentxt.Text += "2";
                    break;

                case "btn3": screentxt.Text += "3";
                    break;

                case "btn4": screentxt.Text += "4";
                    break;

                case "btn5": screentxt.Text += "5";
                    break;

                case "btn6": screentxt.Text += "6";
                    break;

                case "btn7": screentxt.Text += "7";
                    break;

                case "btn8": screentxt.Text += "8";
                    break;

                case "btn9": screentxt.Text += "9";
                    break;


                case "btnPlus":
                    getop = "sum";

                    total1 = Convert.ToDouble(screentxt.Text);
                    
                    screentxt.Clear();

                    break;

                case "btnMinus":
                    getop = "minus";

                    total1 = Convert.ToDouble(screentxt.Text);
                    
                    screentxt.Clear();
                    break;

                case "btnDiv":
                    getop = "div";

                    total1 = Convert.ToDouble(screentxt.Text);
                    
                    screentxt.Clear();

                    break;

                case "btnMul":

                    //if (getop == "mul")
                    //{
                    //    reclick = true;
                    //    btnEqual.PerformClick();
                    //    reclick = false;
                    //    break;
                    //}

                    getop = "mul";

                    total1 = Convert.ToDouble(screentxt.Text);

                    screentxt.Clear();

                    break;

                case "btnEqual":

                    switch (getop)
                    {
                        case "sum":
                            if (total1 != 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            if (total1 == 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            result = total1 + total2;
                            break;

                        case "minus":
                            if (total1 != 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            if (total1 == 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            result = total1 - total2;
                            break;

                        case "div":
                            if (total1 != 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            if (total1 == 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            result = total1 / total2;
                            break;

                        case "mul":
                            if (total1 != 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            if (total1 == 0)
                            {
                                total2 = Convert.ToDouble(screentxt.Text);
                            }

                            result = total1 * total2;
                            break;

                        default:
                            break;

                    }

                    screentxt.Clear();
                    screentxt.Text = Convert.ToString(result);
                    break;

                case "btnClear": 
                    screentxt.Clear();
                    screentxt.Text = "0";
                    total1 = 0;
                    total2 = 0;
                    result = 0;
                    getop = ""; // not passing as null to avoid FormatException error.
                    break;

                case "btnBackspace":

                    if (screentxt.Text == "0")
                    {
                        break;
                    }

                    if (screentxt.TextLength > 0)
                    {
                        screentxt.Text = screentxt.Text.Substring(0, screentxt.TextLength - 1);

                        if (screentxt.TextLength < 1)
                        {
                            screentxt.Text = "0";
                        }

                    }
                    break;

                default: break;
            }
        }

        private void Form1_Load(object sender, EventArgs e) // does all the event handling on load to avoid fake multiple triggers
        {
            btn0.Click += new EventHandler(clickHandler);
            btn1.Click += new EventHandler(clickHandler);
            btn2.Click += new EventHandler(clickHandler);
            btn3.Click += new EventHandler(clickHandler);
            btn4.Click += new EventHandler(clickHandler);
            btn5.Click += new EventHandler(clickHandler);
            btn6.Click += new EventHandler(clickHandler);
            btn7.Click += new EventHandler(clickHandler);
            btn8.Click += new EventHandler(clickHandler);
            btnPlus.Click += new EventHandler(clickHandler);
            btnMinus.Click += new EventHandler(clickHandler);
            btnDiv.Click += new EventHandler(clickHandler);
            btnMul.Click += new EventHandler(clickHandler);
            btnEqual.Click += new EventHandler(clickHandler);
            btnClear.Click += new EventHandler(clickHandler);
            btnBackspace.Click += new EventHandler(clickHandler);
        }
    }
}
