namespace test
{
    partial class Form4
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
            this.cboAlg1 = new System.Windows.Forms.ComboBox();
            this.cmdShuffle = new System.Windows.Forms.Button();
            this.cmdSort = new System.Windows.Forms.Button();
            this.pnlSort1 = new System.Windows.Forms.PictureBox();
            this.lblSamples = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // cboAlg1
            // 
            this.cboAlg1.FormattingEnabled = true;
            this.cboAlg1.Items.AddRange(new object[] {
            "BiDirectional Bubble Sort",
            "Bubble Sort",
            "Bucket Sort",
            "Comb Sort",
            "Cycle Sort",
            "Gnome Sort",
            "Heap Sort",
            "Insertion Sort",
            "Merge Sort",
            "Odd-Even Sort",
            "Pigeon Hole Sort",
            "Quick Sort",
            "Quick Sort with Bubble Sort",
            "Selection Sort",
            "Shell Sort"});
            this.cboAlg1.Location = new System.Drawing.Point(13, 220);
            this.cboAlg1.Name = "cboAlg1";
            this.cboAlg1.Size = new System.Drawing.Size(244, 21);
            this.cboAlg1.TabIndex = 2;
            // 
            // cmdShuffle
            // 
            this.cmdShuffle.Location = new System.Drawing.Point(263, 220);
            this.cmdShuffle.Name = "cmdShuffle";
            this.cmdShuffle.Size = new System.Drawing.Size(75, 23);
            this.cmdShuffle.TabIndex = 4;
            this.cmdShuffle.Text = "Generisi niz";
            this.cmdShuffle.UseVisualStyleBackColor = true;
            this.cmdShuffle.Click += new System.EventHandler(this.cmdShuffle_Click);
            // 
            // cmdSort
            // 
            this.cmdSort.Location = new System.Drawing.Point(347, 220);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(75, 23);
            this.cmdSort.TabIndex = 5;
            this.cmdSort.Text = "Sortiraj";
            this.cmdSort.UseVisualStyleBackColor = true;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // pnlSort1
            // 
            this.pnlSort1.BackColor = System.Drawing.Color.White;
            this.pnlSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort1.Location = new System.Drawing.Point(13, 12);
            this.pnlSort1.Name = "pnlSort1";
            this.pnlSort1.Size = new System.Drawing.Size(409, 200);
            this.pnlSort1.TabIndex = 6;
            this.pnlSort1.TabStop = false;
            // 
            // lblSamples
            // 
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(10, 257);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(77, 13);
            this.lblSamples.TabIndex = 9;
            this.lblSamples.Text = "Broj elemenata";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Brzina sortiranja";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(137, 289);
            this.tbSpeed.Maximum = 100;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(120, 45);
            this.tbSpeed.SmallChange = 10;
            this.tbSpeed.TabIndex = 11;
            this.tbSpeed.TickFrequency = 10;
            this.tbSpeed.Value = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Max";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 257);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "50";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 329);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.pnlSort1);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.cmdShuffle);
            this.Controls.Add(this.cboAlg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form4";
            this.Text = "Algoritmi za sortiranje";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboAlg1;
        private System.Windows.Forms.Button cmdShuffle;
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.PictureBox pnlSort1;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

