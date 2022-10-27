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
    public partial class Help : Form
    {
        string path =
    Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        "static files\\Help.txt"
    );

        string photo = Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
        "static files\\qrCode.png"
    );

        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                File.WriteAllText(path, photo);
            }
            pictureBox1.Image = Image.FromFile(File.ReadAllText(path));
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
