using System;
using System.Windows.Forms;

namespace Kursayin_demo1
{
    public partial class Main : Form
    {
        Timer MyTimer = new Timer();
        public static bool pressedButton = false;
        public Main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pressedButton == false)
            {
                Login login = new Login();
                login.Show();

                Hide();
                MyTimer.Stop();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MyTimer.Interval = (15 * 1000);
            MyTimer.Tick += new EventHandler(timer1_Tick);
            MyTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DontLook dont = new DontLook();

            pressedButton = true;
            dont.Show();
        }
    }
}
