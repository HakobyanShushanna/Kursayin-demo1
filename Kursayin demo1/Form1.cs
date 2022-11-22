using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace Kursayin_demo1
{
    public partial class Main : Form
    {
        Timer MyTimer = new Timer();
        Timer drive = new Timer();
        Timer gif = new Timer();
        Timer changePictureBoxSize = new Timer();
        Timer walkingSound = new Timer();
        Timer driveSound = new Timer();

        SoundPlayer sounds = new SoundPlayer();

        public static bool pressedButton = false;

        int q = 2;
        int k = 0;
        int x, y;
        
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Size = pictureBox1.Size;
            changePictureBoxSize.Stop();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            if (k < 4)
            {
                pictureBox1.Image = Image.FromFile(Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        "static files/moving" + q + ".png"));

                if (q == 1)
                {
                    q++;
                }
                else
                {
                    q--;
                }

                x = pictureBox1.Location.X;
                y = pictureBox1.Location.Y;

                if (x > 0)
                {
                    pictureBox1.Location = new Point(x - 200, y);
                }
                else
                {
                    k++;
                    if (k != 4)
                        pictureBox1.Location = new Point(Width - pictureBox1.Width - 50, y + 50);
                }
            }
            else
            {
                sounds.Stop();
                drive.Stop();
                MyTimer.Start();
                pictureBox1.Visible = false;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox1.Location = pictureBox2.Location;
            gif.Stop();
            drive.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            sounds = new SoundPlayer(Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "static files/walk.wav"));
            sounds.Play();
            walkingSound.Stop();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            sounds.Stop();
            sounds = new SoundPlayer(Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "static files/motor.wav"));
            sounds.Play();
            driveSound.Stop();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Location = new Point(pictureBox2.Location.X - 200, pictureBox2.Location.Y);

            pictureBox2.Image = Image.FromFile(Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        "static files/7sec.gif"
    ));
            walkingSound.Interval = 500;
            walkingSound.Tick += new EventHandler(timer3_Tick);
            walkingSound.Start();

            driveSound.Interval = 2900;
            driveSound.Tick += new EventHandler(timer7_Tick);
            driveSound.Start();

            gif.Interval = 3 * 1000;
            gif.Tick += new EventHandler(timer6_Tick);
            gif.Start();

            changePictureBoxSize.Interval = 1000;
            changePictureBoxSize.Tick += new EventHandler(timer2_Tick);
            changePictureBoxSize.Start();

            drive.Interval = 100;
            drive.Tick += new EventHandler(timer5_Tick);

            MyTimer.Interval = (5 * 1000);
            MyTimer.Tick += new EventHandler(timer1_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DontLook dont = new DontLook();

            pressedButton = true;
            dont.Show();
        }
    }
}
