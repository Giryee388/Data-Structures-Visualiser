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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        int br = 0;

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                br++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";
            br++;
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

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("Stekovi");
            string fileName = "Stekovi/TrenutniStek.txt";
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
            if (br > 0)
            {
                FileStream jebemVamMaterStoNeRaditeNistaSamRadimProjekat = File.Create("da.txt");

                jebemVamMaterStoNeRaditeNistaSamRadimProjekat.Dispose();
            }
            f.Dispose();
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Start();
            if (File.Exists("Stekovi/TrenutniStek.txt"))
            {
                File.Delete("Stekovi/TrenutniStek.txt");
            }
        }



    }
}
