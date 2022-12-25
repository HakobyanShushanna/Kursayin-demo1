using System;
using System.Drawing;
using System.Windows.Forms;
using Kursayin_demo1.static_files;

namespace Kursayin_demo1
{
    public partial class Sudoku : Form
    {
        Timer timer = new Timer();
        Timer saluteTimer = new Timer();

        int n = 9;
        int sec = 0;
        int min = 0;
        int hour = 0;
        int q = 0;
        int row = 0;
        int column = 0;
        int animationSeconds = 0;

        bool startEnter = false;
        bool autoCheck;
        bool startedGame = false;

        string text;

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
            startedGame = true;

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
                        dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Value = SudokuCode.matrix[i, j];
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }

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
                    dataGridView1.Rows[i].Cells[j].ReadOnly = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (animationSeconds >= 5)
            {
                saluteTimer.Stop();
                if (MessageBox.Show($"Դուք հաղթեցիք։\nԱնցած ժամանակը: {text}", "", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    pictureBox1.Visible = false;
                }
            }
            else
            {
                animationSeconds++;
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

            saluteTimer.Interval = 1000;
            saluteTimer.Tick += new EventHandler(timer2_Tick);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int value = 0;
            int matValue = 0;

            if(startedGame == false)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out value);
                int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out matValue);
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }

            if (matValue != SudokuCode.matrix[e.RowIndex, e.ColumnIndex])
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Blue;
            }

            if (checkBox1.Checked == true && value != SudokuCode.answer[e.RowIndex, e.ColumnIndex] && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
            }

            if (CheckForEmptyCells() == true)
            {
                if (CheckResult() == true)
                {
                    text = "";
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
                    saluteTimer.Start();
                    pictureBox1.Visible = true;
                }
                else
                {

                    Loser loser = new Loser();

                    loser.Show();
                }
                GameOver();
            }
        }

        private void GameOver()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
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

                if (checkBox2.Checked == false)
                {
                    dataGridView1.Rows[row].Cells[column].Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }

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
            if (startedGame == false)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Կանգնեցնել")
            {
                timer.Stop();
                dataGridView1.Visible = false;
                button2.Text = "Շարունակել";
            }
            else if (startedGame == true)
            {
                timer.Start();
                button2.Text = "Կանգնեցնել";
                dataGridView1.Visible = true;
            }
        }

        private void InsertValueOfSelectedCell(string button)
        {
            string str = dataGridView1.Rows[row].Cells[column].Style.ForeColor.ToString();
            GetSelectedCell();

            if (dataGridView1.Rows[row].Cells[column].Style.ForeColor == Color.Blue || dataGridView1.Rows[row].Cells[column].Style.ForeColor == Color.Red || dataGridView1.Rows[row].Cells[column].Value.ToString() == "")
            {
                dataGridView1.Rows[row].Cells[column].Value = button;
            }
        }

        private void GetSelectedCell()
        {
            int selectedCellCount =
        dataGridView1.GetCellCount(DataGridViewElementStates.Selected);

            if (selectedCellCount > 0)
            {

                for (int i = 0;
                    i < selectedCellCount; i++)
                {
                    row = dataGridView1.SelectedCells[i].RowIndex;
                    column = dataGridView1.SelectedCells[i].ColumnIndex;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button3.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button3.Text);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button4.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button4.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button6.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button6.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button5.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button5.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button7.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button7.Text);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button12.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button12.Text);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button11.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button11.Text);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button10.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button10.Text);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                AddDraftValue(button9.Text);
            }
            else
            {
                InsertValueOfSelectedCell(button9.Text);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            GetSelectedCell();
            if(dataGridView1.Rows[row].Cells[column].Style.ForeColor != Color.Black)
            {
                dataGridView1.Rows[row].Cells[column].Value = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            GetSelectedCell();

            if (checkBox1.Checked == true)
            {
                autoCheck = checkBox1.Checked;
            }

            if (checkBox2.Checked == true && dataGridView1.Rows[row].Cells[column].Style.ForeColor != Color.Black)
            {
                checkBox1.Checked = false;

                dataGridView1.Rows[row].Cells[column].Style.ForeColor = Color.Gray;
                dataGridView1.Rows[row].Cells[column].Style.Font = new Font("Segoe UI", 8);
            }
            else
            {
                checkBox1.Checked = autoCheck;
                if (dataGridView1.Rows[row].Cells[column].Value.ToString() == "")
                {
                    dataGridView1.Rows[row].Cells[column].Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                }
            }
        }

        private void AddDraftValue(string button)
        {
            if (dataGridView1.Rows[row].Cells[column].Style.ForeColor != Color.Black)
            {
                dataGridView1.Columns[column].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                if (!dataGridView1.Rows[row].Cells[column].Value.ToString().Contains(button))
                {
                    if (dataGridView1.Rows[row].Cells[column].Value.ToString() != "")
                    {
                        dataGridView1.Rows[row].Cells[column].Value += ", ";
                    }

                    dataGridView1.Rows[row].Cells[column].Value += button;
                }

                dataGridView1.Rows[row].Cells[column].Value = sortText();
            }
        }

        private string sortText()
        {
            string[] digits = dataGridView1.Rows[row].Cells[column].Value.ToString().Split(", ");

            for (int i = 0; i < digits.Length - 1; i++)
            {
                for (int j = i + 1; j < digits.Length; j++)
                {
                    if (Convert.ToInt32(digits[i]) > Convert.ToInt32(digits[j]))
                    {
                        string tmp = digits[i];
                        digits[i] = digits[j];
                        digits[j] = tmp;
                    }
                }
            }

            string result = string.Join(", ", digits);

            return result;
        }
    }
}

