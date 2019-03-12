using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BlackDesert_GameCounter
{
    public partial class Form1 : Form
    {
        string date;
        StreamWriter logFile = new StreamWriter(@"log.txt", true);

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = false;

            //第二個參數設定為true表示不覆蓋原本的內容，把新內容直接添加進去
            
            date += DateTime.Now.Year.ToString() + ".";
            date += DateTime.Now.Month.ToString() + ".";
            date += DateTime.Now.Day.ToString() + "-";

            date += DateTime.Now.Hour.ToString()+":";
            date += DateTime.Now.Minute.ToString()+":";
            date += DateTime.Now.Second.ToString();
            logFile.WriteLine(date);
            logFile.Close();
        }

        // ================================================================
        // 計時器
        // ================================================================
        struct Timer_Data
        {
            public int hou;
            public int min;
            public int sec;
        };
        private void Update_Time(Timer_Data t)
        {
            int h=t.hou, m=t.min, s=t.sec;
            string ss = "";

            if (h < 10)
            {
                ss += "0";
            }
            ss += h.ToString();
            ss += ":";
            if (m < 10)
            {
                ss += "0";
            }
            ss += m.ToString();
            ss += ":";
            if (s<10)
            {
                ss += "0";
            }
            ss += s.ToString();
            label1.Text = ss;
        }


        Timer_Data timer_data;
        private void Timer1_Tick(object sender, EventArgs e)
        {

            timer_data.sec++;
            if (timer_data.sec == 60)
            {
                timer_data.min++;
                timer_data.sec = 0;
            }
            if (timer_data.min == 60)
            {
                timer_data.hou++;
                timer_data.min = 0;
            }
            Update_Time(timer_data);
        }
        private void Timer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timer1.Enabled = !timer1.Enabled;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (timer1.Enabled == false)
                {
                    timer_data.hou = 0;
                    timer_data.min = 0;
                    timer_data.sec = 0;
                    Update_Time(timer_data);
                }
            }
        }
        private void Timer_MouseDouClick(object sender, MouseEventArgs e)
        {

        }
        // ================================================================
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }






        // ================================================================

    }
}
