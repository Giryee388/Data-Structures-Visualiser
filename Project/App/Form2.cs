using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 

namespace test
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        Form form1;
        public Form2( Form1 form)
        {
            form1 = form;
        }
        int br = 0,br2 = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Start();
            textBox2.Text = "0";
            if (File.Exists("Drva/trenutnoDrvo.txt"))
            {
                File.Delete("Drva/trenutnoDrvo.txt");
            }
        }

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
                MessageBox.Show("Input must be type int","Error");
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
            Form1 f1 = new Form1();
            Directory.CreateDirectory("Drva");
            string fileName = "Drva/trenutnoDrvo.txt";
            FileStream fs = File.Create(fileName);
            StreamWriter f = new StreamWriter(fs);
            int n = Convert.ToInt32(listBox1.Items.Count.ToString());
            object[] arr = new object[n];
            listBox1.Items.CopyTo(arr, 0);
            for (int i = 0; i < n; i++)
            {
                f.WriteLine(arr[i]);
                //label3.Text = Convert.ToString(arr[i]);
            }
            if (n != 0)
            {
                f1.tree = true;
                f1.stack = false;
                f1.red = false;
                f1.stack = false;
            }
            f.Dispose();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(textBox3.Text);
            textBox3.Text = "";
            br2++;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            try
            {
                int k;
                if (textBox2.Text == "")
                {
                    k = 1;
                }
                k = Convert.ToInt32(textBox2.Text);

                label8.Text = Convert.ToString(br2) + "/" + Convert.ToString(Math.Pow(2, k + 1) - 1);
                if (br2 != Math.Pow(2, k + 1) - 1)
                {
                    button7.Enabled = false;
                }
                else
                {
                    button7.Enabled = true;
                }
            }
            catch
            { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("Drva");
            string fileName = "Drva/trenutnoDrvo.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = File.Create(fileName))
            {

            }
            StreamWriter f = new StreamWriter("Drva/trenutnoDrvo.txt");
            int n = Convert.ToInt32(listBox2.Items.Count.ToString());
            object[] arr = new object[n];
            listBox2.Items.CopyTo(arr, 0);
            for (int i = 0; i < n; i++)
            {
                f.WriteLine(arr[i]);
                //label3.Text = Convert.ToString(arr[i]);
            }
            f.Close();
            this.Close();
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                listBox2.Items.Add(textBox3.Text);
                textBox3.Text = "";
                br2++;
            }
        }
        
    }
}
