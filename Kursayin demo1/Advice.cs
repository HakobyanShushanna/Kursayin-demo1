using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursayin_demo1
{
    public partial class Advice : Form
    {
        string path =
    Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        "static files/AdviceForADay.txt"
    );
        string[] tips;
        int i;
        Random rnd = new Random();
        public Advice()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Random_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                tips = File.ReadAllLines(path);
            }

            i = rnd.Next(0, 7);
            textBox1.Text = tips[i];
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if(i < 6)
            {
                i++;
            }
            else
            {
                i = 0;
            }

            textBox1.Text = tips[i];
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
            }
            else
            {
                i = 6;
            }

            textBox1.Text = tips[i];
        }
    }
}
