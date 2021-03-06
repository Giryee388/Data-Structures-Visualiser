using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace App
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        private int br;
        public int Br
        {
            get { return br; }
            set { br = value; }

        }
        System.Windows.Forms.GroupBox gb1 = new System.Windows.Forms.GroupBox();
        System.Windows.Forms.GroupBox gb2 = new System.Windows.Forms.GroupBox();
        int broj;
        List<System.Windows.Forms.RadioButton> btnLst = new List<System.Windows.Forms.RadioButton>();
        private void Form13_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton[] btnArr = new System.Windows.Forms.RadioButton[2 * br];
            this.Size = new Size(320, 250 + 21 * br);
            Controls.Add(gb1);
            Controls.Add(gb2);
            gb1.Location = new Point(10, 10);
            gb1.Size = new Size(120, 20 + br * 21);
            gb2.Location = new Point(ClientRectangle.Width - 130, 10);
            gb2.Size = new Size(120, 20 + br * 21);
            gb1.Text = "Polazna tacka";
            gb2.Text = "Krajnja tacka";
            broj = 2 * br;
            button1.Location = new Point(ClientRectangle.Width / 2 - button1.Width / 2, ClientRectangle.Height - 20 - button2.Height - button1.Height);
            button2.Location = new Point(ClientRectangle.Width / 2 - button2.Width / 2, ClientRectangle.Height - 10 - button1.Height);
            textBox1.Location = new Point(ClientRectangle.Width / 2 - button1.Width / 2 + label1.Width + 5, ClientRectangle.Height - 30 - button2.Height - button1.Height - textBox1.Height);
            label1.Location = new Point(ClientRectangle.Width / 2 - button2.Width / 2, ClientRectangle.Height - 30 - button2.Height - button1.Height - label1.Height);
            StreamReader f = new StreamReader("Grafovi/trenutniGraf/cvorovi.txt");
            for (int i = 0; i < 2 * br; i += 2)
            {
                btnArr[i] = new RadioButton();
                btnArr[i + 1] = new RadioButton();

                Controls.Add(btnArr[i]);
                Controls.Add(btnArr[i + 1]);

                gb1.Controls.Add(btnArr[i]);
                gb2.Controls.Add(btnArr[i + 1]);

                btnArr[i].Name = Convert.ToString(i + 1);
                btnArr[i + 1].Name = Convert.ToString(i + 2);

                btnArr[i].Text = f.ReadLine();
                btnArr[i + 1].Text = btnArr[i].Text;

                btnArr[i].Location = new Point(5, 15 + (i - i / 2) * 21);
                btnArr[i + 1].Location = new Point(gb2.Width - 10 - btnArr[i + 1].Width, 15 + (i - i / 2) * 21);

                btnLst.Add(btnArr[i]);
                btnLst.Add(btnArr[i + 1]);
            }
            f.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton[] btnArr = new System.Windows.Forms.RadioButton[broj];
            btnLst.CopyTo(btnArr);
            for (int i = 0; i < broj; i += 2)
            {
                if (btnArr[i].Checked)
                {
                    FileStream fs = File.Create("Grafovi/trenutniGraf/" + btnArr[i].Text + ".txt");
                    fs.Dispose();
                    for (int j = 1; j <= broj - 1; j += 2)
                    {
                        if (btnArr[j].Checked)
                        {
                            StreamWriter f = new StreamWriter("Grafovi/trenutniGraf/" + btnArr[i].Text + ".txt");
                            f.WriteLine(btnArr[j].Text);
                            f.WriteLine(textBox1.Text);
                            f.Dispose();
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
