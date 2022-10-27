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
    public partial class DontLook : Form
    {
        int counter = 0;
        Random rnd = new Random();
        public DontLook()
        {
            InitializeComponent();
            no.MouseEnter += OnMouseEnterButton1;
           // MessageBox.Show("x: " + no.Width.ToString() + "---" + (this.Width - no.Height).ToString() + "\n y: " + no.Height.ToString() + "---" + (this.Height - no.Width).ToString());
        }

        private void OnMouseEnterButton1(object sender, EventArgs e)
        {
            if (no.Location.X < 363)
            {
                if (counter == 0)
                {
                    no.Location = new Point(363, 50); // 508, 133   
                }
                else
                    no.Location = new Point(363, rnd.Next(no.Width, this.Height - no.Width));
            }
            else
            {
                if (counter == 30)
                {
                    no.Location = new Point(no.Location.X, 1500);
                }
                no.Location = new Point(rnd.Next(no.Height, this.Width - no.Height), rnd.Next(no.Width, this.Height - no.Width));
                counter++;
            }
        }

        private void yes_Click(object sender, EventArgs e)
        {
            Main.pressedButton = false;
            Close();
        }
    }
}
