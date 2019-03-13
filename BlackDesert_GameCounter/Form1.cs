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
using System.Diagnostics;


namespace BlackDesert_GameCounter
{
    public partial class Form1 : Form
    {
        string logDate;


        struct Timer_Data
        {
            public int hou;
            public int min;
            public int sec;
        };
        Timer_Data timer_data;

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

        // ================================================================
        private void SaveLog()
        {
            StreamWriter logFile = new StreamWriter(@"log.txt", true);

            logDate += "startTime";
            logDate += DateTime.Now.Year.ToString() + ".";
            logDate += DateTime.Now.Month.ToString() + ".";
            logDate += DateTime.Now.Day.ToString() + "-";
            logDate += DateTime.Now.Hour.ToString() + ":";
            logDate += DateTime.Now.Minute.ToString() + ":";
            logDate += DateTime.Now.Second.ToString() + ", ";

            logDate += "gameTime";
            logDate += timer_data.hou.ToString() + ":";
            logDate += timer_data.min.ToString() + ":";
            logDate += timer_data.sec.ToString();

            logDate += item0.ToString() + ", ";
            logDate += item1.ToString() + ", ";
            logDate += item2.ToString() + ", ";
            logDate += item3.ToString() + ", ";
            logDate += item4.ToString() + ", ";
            logDate += item5.ToString() + ", $";
            logDate += total.ToString();

            logFile.WriteLine(logDate);
            logFile.Close();
        }
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = false;
        }

        // ================================================================
        // 計時器
        // ================================================================
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
        private void Bt_Start_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
        // ================================================================

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
                textBox7.Text = (total / 10000).ToString();
            }
            else
            {
                textBox7.Text = total.ToString();
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

        private void Bt_Reset_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                SaveLog();

                item0 = item1 = item2 = item3 = item4 = item5 = 0;
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                Count_Total();

                timer_data.hou = 0;
                timer_data.min = 0;
                timer_data.sec = 0;
                Update_Time(timer_data);
            }
        }

        private void Bt_Log_Click(object sender, EventArgs e)
        {
            Process notePad = new Process();
            notePad.StartInfo.FileName = "notepad.exe";
            notePad.StartInfo.Arguments = "log.txt";
            notePad.Start();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        // ================================================================

    }
}
