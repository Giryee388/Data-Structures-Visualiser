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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        int broj=0;

        System.Windows.Forms.GroupBox gb1 = new System.Windows.Forms.GroupBox();
        System.Windows.Forms.GroupBox gb2 = new System.Windows.Forms.GroupBox();

        List<System.Windows.Forms.RadioButton> btnLstLevi = new List<System.Windows.Forms.RadioButton>();
        List<System.Windows.Forms.RadioButton> btnLstDesni = new List<System.Windows.Forms.RadioButton>();

        Point levi = new Point();
        Point desni = new Point();

        List<Point> veze = new List<Point>();

        private void Form12_Load(object sender, EventArgs e)
        {
            this.Size=new Size(320,500);
            tabControl1.Size = this.Size;

            this.Size = new Size(320, 250 + 21 * broj);
            Controls.Add(gb1);
            Controls.Add(gb2);
            gb1.Location = new Point(10, 40);
            gb1.Size = new Size(120, 20 + 21);
            gb2.Location = new Point(ClientRectangle.Width - 130, 40);
            gb2.Size = new Size(120, 20 + 21);
            gb1.Text = "Polazna tacka";
            gb2.Text = "Krajnja tacka";

            tabPage1.Controls.Add(gb1);
            tabPage1.Controls.Add(gb2);

            button1.Location = new Point(ClientRectangle.Width / 2 - button1.Width / 2, ClientRectangle.Height - 20 - button2.Height - button1.Height- 22 );
            button2.Location = new Point(ClientRectangle.Width / 2 - button2.Width / 2, ClientRectangle.Height - 10 - button1.Height -22 );
            button3.Location = new Point(ClientRectangle.Width / 2 - button2.Width - 2, 12);
            button4.Location = new Point(ClientRectangle.Width / 2 + 2, 12);
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void restartInput()
        {
            foreach (RadioButton i in btnLstLevi)
            {
                btnLstLevi.Remove(i);
            }
            foreach (RadioButton i in btnLstDesni)
            {
                btnLstDesni.Remove(i);
            }

            this.Size = new Size(320, 206 + 21);
            Controls.Add(gb1);
            Controls.Add(gb2);
            gb1.Location = new Point(10, 10);
            gb1.Size = new Size(120, 20 + 1 * 21);
            gb2.Location = new Point(ClientRectangle.Width - 130, 10);
            gb2.Size = new Size(120, 20 + 1 * 21);
            gb1.Text = "Polazna tacka";
            gb2.Text = "Krajnja tacka";

            button1.Location = new Point(ClientRectangle.Width / 2 - button1.Width / 2, ClientRectangle.Height - 20 - button2.Height - button1.Height);
            button2.Location = new Point(ClientRectangle.Width / 2 - button2.Width / 2, ClientRectangle.Height - 10 - button1.Height);
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton levii = new RadioButton();
            RadioButton desnii = new RadioButton();
            foreach (RadioButton i in btnLstLevi)
            {
                if (i.Checked == true)
                {
                    levii = i;
                    levi = new Point(i.Location.X + i.Size.Width, i.Location.Y + i.Size.Height / 2);
                }
            }
            foreach (RadioButton i in btnLstDesni)
            {
                if (i.Checked == true)
                {
                    desnii = i;
                    desni = new Point(i.Location.X, i.Location.Y + i.Size.Height / 2);
                }
            }
            Graphics g = CreateGraphics();
            g.DrawLine(Pens.Black, levi, desni);

            FileStream fs = File.Create("Grafovi/trenutniGraf/" + levii.Text + ".txt");
            fs.Dispose();

            StreamWriter f = new StreamWriter("Grafovi/trenutniGraf/" + levii.Text + ".txt");
            f.WriteLine(desnii.Text);
            f.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RadioButton levi = new RadioButton();
            RadioButton desni = new RadioButton();

            Controls.Add(levi);
            Controls.Add(desni);

            tabPage1.Controls.Add(levi);
            tabPage1.Controls.Add(desni);

            gb1.Controls.Add(levi);
            gb2.Controls.Add(desni);

            levi.Name = Convert.ToString(broj);
            desni.Name = Convert.ToString(broj);

            levi.Text = Convert.ToString(broj);
            desni.Text = Convert.ToString(broj);

            levi.Location = new Point(gb1.Location.X + 5, 15 + broj * 21);
            desni.Location = new Point(gb2.Width - 10 - desni.Width, 15 + broj * 21);

            btnLstLevi.Add(levi);
            btnLstDesni.Add(desni);

            levi.CheckedChanged += new System.EventHandler(levi_CheckedChanged);
            desni.CheckedChanged += new System.EventHandler(desni_CheckedChanged);

            broj++;
            gb2.Size = new Size(120, 20 + broj * 21);
            gb1.Size = new Size(120, 20 + broj * 21);

            this.Size = new Size(320, 250 + 21 * broj);
            tabControl1.Size = this.Size;
            button1.Location = new Point(ClientRectangle.Width / 2 - button1.Width / 2, ClientRectangle.Height - 20 - button2.Height - button1.Height - 22);
            button2.Location = new Point(ClientRectangle.Width / 2 - button2.Width / 2, ClientRectangle.Height - 10 - button1.Height - 22);

        }

        protected void levi_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton i in btnLstLevi)
            {
                if (i.Checked == true)
                {
                    levi = new Point(i.Location.X + i.Size.Width, i.Location.Y + i.Size.Height / 2);
                }
            }
            foreach (RadioButton i in btnLstDesni)
            {
                if (i.Checked == true)
                {
                    desni = new Point(i.Location.X + i.Size.Width, i.Location.Y + i.Size.Height / 2);
                }
            }
        }
        protected void desni_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (broj == 0)
            {

            }
            else
            {
                Controls.Remove(btnLstLevi[btnLstLevi.Count - 1]);
                Controls.Remove(btnLstDesni[btnLstDesni.Count - 1]);

                tabPage1.Controls.Remove(btnLstLevi[btnLstLevi.Count - 1]);
                tabPage1.Controls.Remove(btnLstDesni[btnLstDesni.Count - 1]);

                gb1.Controls.Remove(btnLstLevi[btnLstLevi.Count - 1]);
                gb1.Controls.Remove(btnLstDesni[btnLstDesni.Count - 1]);

                btnLstDesni.RemoveAt(btnLstDesni.Count-1);
                btnLstLevi.RemoveAt(btnLstLevi.Count - 1);
                
                broj--;

                gb2.Size = new Size(120, 20 + broj * 21);
                gb1.Size = new Size(120, 20 + broj * 21);

                this.Size = new Size(320, 250 + 21 * broj);
                tabControl1.Size = this.Size;
                button1.Location = new Point(ClientRectangle.Width / 2 - button1.Width / 2, ClientRectangle.Height - 20 - button2.Height - button1.Height - 22);
                button2.Location = new Point(ClientRectangle.Width / 2 - button2.Width / 2, ClientRectangle.Height - 10 - button1.Height - 22);
                
            }
        }
    }
}
