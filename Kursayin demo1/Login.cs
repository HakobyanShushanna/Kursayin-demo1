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
    public partial class Login : Form
    {
        string path =
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"static files\UserNameAndPassword.txt"
            );

        string[] nameAndPassword;
        public Login()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                nameAndPassword = File.ReadAllLines(path);
            }

            if (String.Compare(Name.Text, nameAndPassword[0]) == 0 && String.Compare(Password.Text, nameAndPassword[1]) == 0)
            {
                Menu menu = new Menu();

                menu.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect Name or Password", "", MessageBoxButtons.OK);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
