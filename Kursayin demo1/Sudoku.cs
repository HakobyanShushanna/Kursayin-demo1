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
    public partial class Sudoku : Form
    {
        int n = 9;

        public Sudoku()
        {
            InitializeComponent();
        }
        // 426
        private void InitDataGridView()
        {
            dataGridView1.Columns.Clear();

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), "");
                dataGridView1.Columns[i].Width = 42;
            }

            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Height = 42;
            }

            dataGridView1.AllowUserToAddRows = false;
        }

        private void PaintDataGridView()
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {

                    if (((i / 3) % 2) == ((j / 3) % 2))
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(212, 212, 212);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Sudoku_Load(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            PaintDataGridView();

            // horizontal
            for (int i = 0; i < n; i++)
            {

            }
        }
    }
}
