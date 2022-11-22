
namespace Kursayin_demo1
{
    partial class Sudoku
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.easy = new System.Windows.Forms.RadioButton();
            this.medium = new System.Windows.Forms.RadioButton();
            this.difficult = new System.Windows.Forms.RadioButton();
            this.timing = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(345, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(423, 420);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "Սկսել";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 140);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(281, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Ստուգել խաղի ժամանակ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // easy
            // 
            this.easy.AutoSize = true;
            this.easy.Location = new System.Drawing.Point(9, 175);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(82, 29);
            this.easy.TabIndex = 4;
            this.easy.TabStop = true;
            this.easy.Text = "Հեշտ";
            this.easy.UseVisualStyleBackColor = true;
            // 
            // medium
            // 
            this.medium.AutoSize = true;
            this.medium.Location = new System.Drawing.Point(9, 210);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(90, 29);
            this.medium.TabIndex = 5;
            this.medium.TabStop = true;
            this.medium.Text = "Միջին";
            this.medium.UseVisualStyleBackColor = true;
            // 
            // difficult
            // 
            this.difficult.AutoSize = true;
            this.difficult.Location = new System.Drawing.Point(7, 245);
            this.difficult.Name = "difficult";
            this.difficult.Size = new System.Drawing.Size(85, 29);
            this.difficult.TabIndex = 6;
            this.difficult.TabStop = true;
            this.difficult.Text = "Բարդ";
            this.difficult.UseVisualStyleBackColor = true;
            // 
            // timing
            // 
            this.timing.AutoSize = true;
            this.timing.Location = new System.Drawing.Point(138, 23);
            this.timing.Name = "timing";
            this.timing.Size = new System.Drawing.Size(0, 25);
            this.timing.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(176, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 54);
            this.button2.TabIndex = 8;
            this.button2.Text = "Կանգեցնել";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Sudoku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.timing);
            this.Controls.Add(this.difficult);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Sudoku";
            this.Text = "Սուդոկու";
            this.Load += new System.EventHandler(this.Sudoku_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton easy;
        private System.Windows.Forms.RadioButton medium;
        private System.Windows.Forms.RadioButton difficult;
        private System.Windows.Forms.Label timing;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
    }
}