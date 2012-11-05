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
            this.components = new System.ComponentModel.Container();
            this.wordToShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.percentage = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.check = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).BeginInit();
            this.SuspendLayout();
            // 
            // wordToShow
            // 
            this.wordToShow.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordToShow.Location = new System.Drawing.Point(12, 12);
            this.wordToShow.Name = "wordToShow";
            this.wordToShow.ReadOnly = true;
            this.wordToShow.Size = new System.Drawing.Size(407, 39);
            this.wordToShow.TabIndex = 0;
            this.wordToShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.wordToShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.wordToShow_MouseClick);
            this.wordToShow.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.wordToShow.MouseEnter += new System.EventHandler(this.wordToShow_MouseEnter);
            this.wordToShow.MouseHover += new System.EventHandler(this.wordToShow_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "I have used this word today!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // percentage
            // 
            this.percentage.AutoSize = true;
            this.percentage.Location = new System.Drawing.Point(395, 129);
            this.percentage.Name = "percentage";
            this.percentage.Size = new System.Drawing.Size(24, 13);
            this.percentage.TabIndex = 5;
            this.percentage.Text = "1/2";
            // 
            // toolTip2
            // 
            this.toolTip2.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip2_Popup);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::WordOfTheDay.Properties.Resources.postpone1;
            this.pictureBox1.Location = new System.Drawing.Point(398, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 25);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // check
            // 
            this.check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check.Image = global::WordOfTheDay.Properties.Resources.checkmark;
            this.check.Location = new System.Drawing.Point(180, 66);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(71, 54);
            this.check.TabIndex = 3;
            this.check.TabStop = false;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 151);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.percentage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.check);
            this.Controls.Add(this.wordToShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Word of The Day";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.check)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wordToShow;
        private System.Windows.Forms.PictureBox check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label percentage;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

