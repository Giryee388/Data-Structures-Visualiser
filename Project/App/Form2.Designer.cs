﻿namespace test
{
    partial class Form2
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, -2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(569, 295);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(561, 269);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kompletno drvo";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(375, -11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Nivo 0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Prilikom unosa pisemo samo niz, raspored cvorova je vec poznat";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(378, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(177, 238);
            this.listBox1.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(176, 191);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Obrisi sve elemente";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(176, 162);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(176, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Obrisi poslednji element";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Generisi stablo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Potvrdi ulaz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unos elementa jedan po jedan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stablo kod koga su svi nivoi popunjeni izuzev poslednjeg i to\r\ntako da su popunja" +
                "vanje vrsi sa leva na desno (ne moraju svi\r\ncvorovi da postoje ali moraju da bud" +
                "u popunjeni sa leva strane)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button7);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(561, 269);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Savrseno drvo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "label8";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(176, 192);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 23);
            this.button5.TabIndex = 21;
            this.button5.Text = "Obrisi sve elemente";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(176, 162);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(176, 23);
            this.button6.TabIndex = 20;
            this.button6.Text = "Obrisi poslednji element";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(15, 237);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(337, 23);
            this.button7.TabIndex = 19;
            this.button7.Text = "Generisi stablo";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(176, 133);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(176, 23);
            this.button8.TabIndex = 18;
            this.button8.Text = "Potvrdi ulaz";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Unos elementa jedan po jedan";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 136);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(144, 20);
            this.textBox3.TabIndex = 16;
            this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyUp);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(378, 26);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(177, 238);
            this.listBox2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(166, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "h =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Unesi visinu stabla";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(297, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Savrseno binarno stablo je stablo kod koga su svi\r\nlistovi na istom nivou, takodj" +
                "e svaki roditelj ima tacno 2 deteta";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 292);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Novo drvo";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}