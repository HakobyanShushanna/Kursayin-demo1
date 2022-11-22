
namespace Kursayin_demo1
{
    partial class Advice
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.Random = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(28, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(555, 410);
            this.textBox1.TabIndex = 0;
            // 
            // Ok
            // 
            this.Ok.Location = new System.Drawing.Point(604, 13);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(187, 56);
            this.Ok.TabIndex = 1;
            this.Ok.Text = "Փակել";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Random
            // 
            this.Random.Location = new System.Drawing.Point(604, 75);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(187, 65);
            this.Random.TabIndex = 2;
            this.Random.Text = "Պատահական խորհուրդ";
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Random_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(604, 147);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(187, 65);
            this.Next.TabIndex = 3;
            this.Next.Text = "Հաջորդ խորհուրդը";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Previous
            // 
            this.Previous.Location = new System.Drawing.Point(604, 219);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(187, 62);
            this.Previous.TabIndex = 4;
            this.Previous.Text = "Նախորդ խորհուրդը";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Advice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Random);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "Advice";
            this.Text = "Խորհուրդ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Previous;
    }
}