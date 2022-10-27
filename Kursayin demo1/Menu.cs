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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            UpdateStatus(e.ClickedItem);
        }

        private void UpdateStatus(ToolStripItem item)
        {
            if (item != null)
            {
                if (item.Text == "Sudoku")
                {
                    Sudoku sudoku = new Sudoku();

                    sudoku.Show();
                }
                else if (item.Text == "Advice")
                {
                    Advice tips = new Advice(); 

                    tips.Show();
                }
                else if (item.Text == "Help")
                {
                    Help help = new Help();

                    help.Show();
                }
                else if(item.Text == "About")
                {
                    About about = new About();

                    about.Show();
                }
                else if (item.Text == "Exit")
                {
                    if (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
