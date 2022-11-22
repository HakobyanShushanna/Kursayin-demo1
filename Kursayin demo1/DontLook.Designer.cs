
namespace Kursayin_demo1
{
    partial class DontLook
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
            this.label1 = new System.Windows.Forms.Label();
            this.no = new System.Windows.Forms.Button();
            this.yes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Արա ուզբե՛կ, գրած էր չսեղմել։ Հիմա դու քյալ ե՞ս";
            // 
            // no
            // 
            this.no.Location = new System.Drawing.Point(38, 132);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(131, 48);
            this.no.TabIndex = 1;
            this.no.Text = "Չէ";
            this.no.UseVisualStyleBackColor = true;
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(363, 132);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(131, 48);
            this.yes.TabIndex = 2;
            this.yes.Text = "Հա";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // DontLook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 225);
            this.ControlBox = false;
            this.Controls.Add(this.yes);
            this.Controls.Add(this.no);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DontLook";
            this.Text = "Չբացել";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button no;
        private System.Windows.Forms.Button yes;
    }
}