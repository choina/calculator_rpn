using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_rnp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            field.ReadOnly = true;
            field.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            field.Text += "2";
        }

        private void one_Click(object sender, EventArgs e)
        {
            field.Text += "1";
        }

        private void three_Click(object sender, EventArgs e)
        {
            field.Text += "3";
        }

        private void four_Click(object sender, EventArgs e)
        {
            field.Text += "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            field.Text += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            field.Text += "6";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            field.Text += "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            field.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            field.Text += "9";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            field.Text += "0";
        }

        private void plus_Click(object sender, EventArgs e)
        {
            field.Text += "+";
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            field.Text += "*";
        }

        private void equal_Click(object sender, EventArgs e)
        {
            try { field.Text = Class1.Calculate(field.Text).ToString(); }
            catch (MyException ex) { field.Text = ex.type; }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            field.Text += "-";
        }

        private void factorial_Click(object sender, EventArgs e)
        {
            field.Text += "!";
        }

        private void division_Click(object sender, EventArgs e)
        {
            field.Text += "/";
        }

        private void percent_Click(object sender, EventArgs e)
        {
            field.Text += "%";
        }

        private void exponentation_Click(object sender, EventArgs e)
        {
            field.Text += "^";
        }

        private void r_bracket_Click(object sender, EventArgs e)
        {
            field.Text += ")";
        }

        private void l_bracket_Click(object sender, EventArgs e)
        {
            field.Text += "(";
        }

        private void ce_Click(object sender, EventArgs e)
        {
            field.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            field.Text += "cos(";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            field.Text += "sin(";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            field.Text += "tg(";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            field.Text += "^2";
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            field.Text += "sqrt(";
        }
    }
}
