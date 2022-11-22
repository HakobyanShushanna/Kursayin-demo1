using System;
using System.Drawing;
using System.Windows.Forms;
using Kursayin_demo1.static_files;

namespace Kursayin_demo1
{
    public partial class Sudoku : Form
    {
        Timer timer = new Timer();

        int n = 9;
        int sec = 0;
        int min = 0;
        int hour = 0;
        int q = 0;

        bool blueNumbers;
        bool startEnter = false;
        public Sudoku()
        {
            InitializeComponent();
        }

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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (((i / 3) % 2) == ((j / 3) % 2))
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(212, 212, 212);
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            blueNumbers = false;
            sec = 0;
            min = 0;
            hour = 0;
            StartGame();
            q++;
        }

        private void StartGame()
        {
            button2.Text = "Կանգնեցնել";
            sec = 0;
            min = 0;
            hour = 0;

            if (q == 0)
            {
                InitDataGridView();
            }
            ClearDataGridView();
            PaintDataGridView();

            if (easy.Checked == true)
            {
                SudokuCode.numberOfRemovingPieces = 40;
            }
            else if (medium.Checked == true)
            {
                SudokuCode.numberOfRemovingPieces = 50;
            }
            else
            {
                SudokuCode.numberOfRemovingPieces = 60;
            }

            SudokuCode.fillValues();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (SudokuCode.matrix[i, j] != 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = SudokuCode.matrix[i, j];
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }

            blueNumbers = true;

            startEnter = true;
            timer.Start();
        }

        private void ClearDataGridView()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (min < 10 && sec < 10)
            {
                label1.Text = $"{hour} : 0{min} : 0{sec}";
            }
            else if (min >= 10 && sec < 10)
            {
                label1.Text = $"{hour} : {min} : 0{sec}";
            }
            else if (min < 10 && sec >= 10)
            {
                label1.Text = $"{hour} : 0{min} : {sec}";
            }
            else if (min >= 10 && sec >= 10)
            {
                label1.Text = $"{hour} : {min} : {sec}";
            }

            if (sec >= 60)
            {
                min++;
                sec = 0;
            }
            if (min >= 60)
            {
                hour++;
                min = 0;
            }
            sec++;
        }

        private void Sudoku_Load(object sender, EventArgs e)
        {
            easy.Checked = true;
            InitDataGridView();
            PaintDataGridView();

            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (blueNumbers == true)
            {
                int value = 0;
                int matValue = 0;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out value);
                    int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out matValue);
                }

                if (matValue != SudokuCode.matrix[e.RowIndex, e.ColumnIndex])
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Blue;
                }

                if (checkBox1.Checked == true && value != SudokuCode.answer[e.RowIndex, e.ColumnIndex])
                {
                    MessageBox.Show("Incorrect Input");
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                }

                if (CheckForEmptyCells() == true)
                {
                    if (CheckResult() == true)
                    {
                        string text = "";
                        if (min < 10 && sec < 10)
                        {
                            text = $"{hour} : 0{min} : 0{sec}";
                        }
                        else if (min >= 10 && sec < 10)
                        {
                            text = $"{hour} : {min} : 0{sec}";
                        }
                        else if (min < 10 && sec >= 10)
                        {
                            text = $"{hour} : 0{min} : {sec}";
                        }
                        else if (min >= 10 && sec >= 10)
                        {
                            text = $"{hour} : {min} : {sec}";
                        }
                        timer.Stop();
                        MessageBox.Show($"You won!\n Time elapsed: {text}");
                    }
                    else
                    {
                        Loser loser = new Loser();

                        loser.Show();
                    }
                }
            }
        }

        private bool CheckForEmptyCells()
        {
            int value;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        return false;
                    }

                    int.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out value);

                    if (value == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckResult()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value) != SudokuCode.answer[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (startEnter == true)
            {
                PaintDataGridView();
                int similiarValue;
                int value = 0;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out value);
                }

                // Vertical
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.FromArgb(209, 215, 255);
                }

                // Horizontal
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Rows[i].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(209, 215, 255);
                }

                //Square
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if ((i) / 3 == (e.RowIndex) / 3 && (j) / 3 == (e.ColumnIndex) / 3)
                        {
                            dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(209, 215, 255);
                        }
                    }
                }

                // All same numbers

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            int.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out similiarValue);
                            if (similiarValue == value && value >= 1 && value <= 9)
                            {
                                dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(209, 215, 255);
                            }
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Կանգնեցնել")
            {
                timer.Stop();
                button2.Text = "Շարունակել";
            }
            else
            {
                timer.Start();
                button2.Text = "Կանգնեցնել";
            }
        }
    }
}
