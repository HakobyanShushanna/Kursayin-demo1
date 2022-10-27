using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursayin_demo1
{
    public partial class About : Form
    {
        float fontSize = 14;
        float change = 0.1f;
        int q = 0;

        public About()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 13-1, 12-2, 11-3, 10-4, 9-5
        // 10-6, 11-7, 12-8, 13-9, 14-10
        // 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((q / 50) % 2 == 1)
            {
                fontSize += change;
            }
            else
            {
                fontSize -= change;
            }
            if (q % 50 == 0)
            {
                if (((q - 1) / 50) % 2 == 0)
                {
                    fontSize += change;
                }
                else
                {
                    fontSize -= change;
                }
            }
            q++;
            label4.Font = new Font("Segoe UI", fontSize);
        }

        private void About_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (5);
            MyTimer.Tick += new EventHandler(timer1_Tick);
            MyTimer.Start();
        }

        // 
    }
}
