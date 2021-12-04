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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        int br = 0, br2 = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);
            if (isNumeric)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                br++;
            }
            else
            {
                MessageBox.Show("Input must be type int", "Error");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("Grafovi/trenutniGraf"))
            {
                Directory.Delete("Grafovi/trenutniGraf",true);
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                int n;
                bool isNumeric = int.TryParse(textBox1.Text, out n);
                if (isNumeric)
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Text = "";
                    br++;
                }
                else
                {
                    MessageBox.Show("Input must be type int", "Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(br - 1);
                br--;
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("Grafovi/trenutniGraf");
            string fileName = "Grafovi/trenutniGraf/cvorovi.txt";
            FileStream fs = File.Create(fileName);
            StreamWriter f = new StreamWriter(fs);
            int n = Convert.ToInt32(listBox1.Items.Count.ToString());
            object[] arr = new object[n];
            listBox1.Items.CopyTo(arr, 0);
            for (int i = 0; i < n; i++)
            {
                f.WriteLine(arr[i]);
            }
            if (br > 0)
            {
                FileStream rasicuNaduvajMiSeSKuracOvajZabagreli = File.Create("da.txt");

                rasicuNaduvajMiSeSKuracOvajZabagreli.Dispose();
            }
            f.Dispose();
            Form12 f12 = new Form12();
            f12.Br = br;
            f12.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);
            if (isNumeric)
            {
                listBox2.Items.Add(textBox3.Text);
                textBox3.Text = "";
                br2++;
            }
            else
            {
                MessageBox.Show("Input must be type int", "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(br2 - 1);
                br2--;
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("Grafovi/trenutniGraf");
            string fileName = "Grafovi/trenutniGraf/cvorovi.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = File.Create(fileName))
            {

            }
            StreamWriter f = new StreamWriter("Grafovi/trenutniGraf/cvorovi.txt");
            int n = Convert.ToInt32(listBox2.Items.Count.ToString());
            object[] arr = new object[n];
            listBox2.Items.CopyTo(arr, 0);
            for (int i = 0; i < n; i++)
            {
                f.WriteLine(arr[i]);
                //label3.Text = Convert.ToString(arr[i]);
            }
            if (br2 > 0)
            {
                FileStream rasicuNaduvajMiSeSKuracOvajZabagreli = File.Create("da.txt");

                rasicuNaduvajMiSeSKuracOvajZabagreli.Dispose();
            }
            f.Close();
            Form13 f13 = new Form13();
            f13.Br = br2;
            f13.ShowDialog();
            this.Close();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                int n;
                bool isNumeric = int.TryParse(textBox3.Text, out n);
                if (isNumeric)
                {
                    listBox2.Items.Add(textBox3.Text);
                    textBox3.Text = "";
                    br++;
                }
                else
                {
                    MessageBox.Show("Input must be type int", "Error");
                }
            }
        }    
    }
}
