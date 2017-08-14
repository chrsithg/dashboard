using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication_09產能看板
{
    public partial class Form1 : Form
    {
        Random rnd;
        int cycleTime = 2000;
        float c1, c2, c3, c41, c42, c5;
        float a1,a3, a4, a5;
        bool isStart = false;

        private void button2_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(this.btnC1.Text);
            this.btnC1.Text = (n++).ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isStart = !isStart;
            if (isStart)
                Start();
            else
                Stop();
        }

        float a2, b1, b2, b3;
        int d1, d2, d3,d5, d6, d7;
        float d4,d8;
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            timer1.Interval = cycleTime;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int cycle = rnd.Next(1, 5);
            //cycleTime = cycle * 1000;
            //timer1.Interval = cycleTime;
            c1 = rnd.Next(2, 4);
            c2 = rnd.Next(2, 4);
            c3 = rnd.Next(2, 4);
            c41 = rnd.Next(2, 6);
            c42 = rnd.Next(2, 6);
            c5 = rnd.Next(2, 3);
            //
            a1 = c1 + c2 + c3 + (c41 + c42) / 2 + c5;
            float[] max = new float[] { c1, c2, c3 };
            a2 = (c41 + c42) / 2 > max.Max() ? ((c41 + c42) / 2) * 5 : a1;
            //
            b1 = a1 / a2;
            //b2 = 13800 / a2;
            //

            if (c41 > max.Max())
                btnC41.BackColor = Color.Red;
            else
                btnC41.BackColor = Color.FromArgb(0, 192, 0);

            if (c42 > max.Max())
                btnC42.BackColor = Color.Red;
            else
                btnC42.BackColor = Color.FromArgb(0, 192, 0);
            //-----------------------------------------
            //生產製程監控CycleTime
            //-----------------------------------------
            btnC1.Text = c1.ToString();
            btnC2.Text = c2.ToString();
            btnC3.Text = c3.ToString();
            btnC41.Text = c41.ToString();
            btnC42.Text = c42.ToString();
            btnC5.Text = c5.ToString();
            //產線平衡率
            btnB1.Text = b1.ToString("0.00");

            //----------------------------------------
            //產能評估
            //---------------------------------------
            btnA1.Text = a1.ToString();
            btnA2.Text = a2.ToString();
            a3 = a1 / a2;
            btnA3.Text = a3.ToString("0.00");//產線平衡率

            //基本資料
            d1 = Convert.ToInt16(string.IsNullOrEmpty(txtBox1.Text) ? "8" : txtBox1.Text);
            d2 = Convert.ToInt16(string.IsNullOrEmpty(txtBox2.Text) ? "20" : txtBox2.Text);
            d5 = Convert.ToInt16(string.IsNullOrEmpty(txtBox5.Text) ? "5" : txtBox5.Text);
            d7 = Convert.ToInt16(string.IsNullOrEmpty(txtBox7.Text) ? "22000" : txtBox7.Text);
            d3 = (d1 * 60 - d2) *60;
            txtBox3.Text = d3.ToString();
            d6 = d3 * d5;
            txtBox6.Text = d6.ToString();
            d4 = d7 / 30;
            txtBox4.Text = d4.ToString();
            d8 = d4 / d3;
            txtBox8.Text = d8.ToString();
            //
            b2 = d6 / a2;
            btnB2.Text = b2.ToString("0.");
            a4 = b2;
            btnA4.Text = a4.ToString();
            a5 = a4 * 245;
            btnA5.Text = a5.ToString();
            b3 = (d6 / a1) - b2;
            btnB3.Text = Math.Floor(b3).ToString("0.");
        }

        void Start()
        {
            timer1.Start();
        }

        void Stop()
        {
            timer1.Stop();
        }
    }
}
