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
        int fontSize = 14;
        bool smaller = false;
        int x, y;
        public About()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = label4.Location.X;
            y = label4.Location.Y;

            if (label4.Font.Size == 8 || label4.Font.Size == 30)
            {
                smaller = !smaller;
            }

            fontSize = smaller == true ? fontSize - 1 : fontSize + 1;
            x = smaller == true ? x + 6 : x - 6;
            y = smaller == true ? y + 1 : y - 1;

            label4.Font = new Font("Segoe UI", fontSize);
            label4.Location = new Point(x, y);
        }

        private void About_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (50);
            MyTimer.Tick += new EventHandler(timer1_Tick);
            MyTimer.Start();
        }
    }
}
