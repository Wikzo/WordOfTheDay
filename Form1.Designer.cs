namespace WordOfTheDay
{
    partial class Form1
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
            this.wordToShow = new System.Windows.Forms.TextBox();
            this.check = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.check)).BeginInit();
            this.SuspendLayout();
            // 
            // wordToShow
            // 
            this.wordToShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordToShow.Location = new System.Drawing.Point(12, 12);
            this.wordToShow.Name = "wordToShow";
            this.wordToShow.Size = new System.Drawing.Size(244, 26);
            this.wordToShow.TabIndex = 0;
            this.wordToShow.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // check
            // 
            this.check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check.Image = global::WordOfTheDay.Properties.Resources.checkmark;
            this.check.Location = new System.Drawing.Point(155, 44);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(101, 79);
            this.check.TabIndex = 3;
            this.check.TabStop = false;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "I have used this word today!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check);
            this.Controls.Add(this.wordToShow);
            this.Name = "Form1";
            this.Text = "Word of the Day";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.check)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordToShow;
        private System.Windows.Forms.PictureBox check;
        private System.Windows.Forms.Label label1;
    }
}

