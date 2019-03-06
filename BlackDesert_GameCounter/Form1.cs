using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackDesert_GameCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const float item0_coef = 10000;
        const float item1_coef = 3000;
        const float item2_coef = 1000;
        const float item3_coef = 500;
        const float item4_coef = 300;
        const float item5_coef = 150;

        float item0 = 0;
        float item1 = 0;
        float item2 = 0;
        float item3 = 0;
        float item4 = 0;
        float item5 = 0;
        float total = 0;

        bool gen10K_enable = true;

        private void Count_Total()
        {

            total = 
                item0 * item0_coef +
                item1 * item1_coef +
                item2 * item2_coef +
                item3 * item3_coef +
                item4 * item4_coef +
                item5 * item5_coef;

            if (gen10K_enable)
            {
                total /= 10000;
            }

            textBox7.Text = total.ToString();
        }
        private void Bt_clear(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                item0 = item1 = item2 = item3 = item4 = item5 = 0;
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                Count_Total();
                //MessageBox.Show("left");
            }
            else
            {
                //MessageBox.Show("right");
            }
        }

        private void Lv0_MouseCkick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ++item0;
            }
            else
            {
                --item0;
            }
            textBox1.Text = item0.ToString();
            Count_Total();
        }

        private void Lv1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ++item1;
            }
            else
            {
                --item1;
            }
            textBox2.Text = item1.ToString();
            Count_Total();
        }

        private void Lv2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ++item2;
            }
            else
            {
                --item2;
            }
            textBox3.Text = item2.ToString();
            Count_Total();
        }

        private void Lv3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ++item3;
            }
            else
            {
                --item3;
            }
            textBox4.Text = item3.ToString();
            Count_Total();
        }

        private void Lv4_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ++item4;
            }
            else
            {
                --item4;
            }
            textBox5.Text = item4.ToString();
            Count_Total();
        }

        private void Lv5_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ++item5;
            }
            else
            {
                --item5;
            }
            textBox6.Text = item5.ToString();
            Count_Total();
        }

        private void Gen10k_Click(object sender, EventArgs e)
        {
            gen10K_enable = !gen10K_enable;
            Count_Total();
        }
    }
}
