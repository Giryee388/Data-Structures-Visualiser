
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using App;
using System.Runtime.InteropServices;

namespace test
{
    public partial class Form1 : Form
    {

        private bool isCollapsedFile = true;
        private bool isCollapsedSimulate = true;
        private bool isMaximized = true;
        public bool preOrderAnalizaKeepGoing = false;
        /*
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );*/

        Drvo _drvo;
        Lista _lista;
        public Form1()
        {
            InitializeComponent();
        }

        public double zoom = 1;
        public int n = 0;

        //is moving, koristi se za pomeranje svega sa drag n drop
        //Tacke na osnovu koji se crta, D je centar ekrana oko koga se crta sve, B i C se koristi za pomeranje tacno D pri drag and drop-u misa
        Point B = new Point();
        Point C = new Point();
        Point D = new Point();
        int isMoving = 0;

        //kad budem fix performance za drvo ovo ide u smece  - Jovan
        public int?[] arr = new int?[4096];

        //Za sta se trenutno koristi program
        bool tree = false;
        bool list = false;
        bool red = false;
        bool stack = false;

        Element lista = new Element();
        Node koren = new Node();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            if (tree == true)
            {
                double precnik = 50 * zoom;
                double offsetOdD = 150 * zoom;
                double yOffsetDece = 90 * zoom;
                double xOffsetDeceBase = 20 * zoom;


                koren = _drvo.generisiDrvoIzNiza(arr, koren, 0, n);
                koren.value = arr[0];

                Graphics g = e.Graphics;
                Font drawFont = new Font("Arial", Convert.ToInt32(zoom * 16));
                SolidBrush cetka = new SolidBrush(Color.Black);
                SolidBrush stringCetka = new SolidBrush(Color.White);
                Pen olovka = new Pen(Color.Black, Convert.ToInt32(zoom * 6));

                Point parent = new Point();


                //crtanje korena
                if (n > 0)
                {
                    parent.X = D.X - Convert.ToInt32(precnik) / 2;
                    parent.Y = D.Y - Convert.ToInt32(offsetOdD) - Convert.ToInt32(precnik) / 2;

                    g.FillEllipse(cetka, parent.X, parent.Y, Convert.ToInt32(precnik), Convert.ToInt32(precnik));
                    parent.Y = D.Y - Convert.ToInt32(offsetOdD) - Convert.ToInt32(precnik) / 3;
                    parent.X = D.X - Convert.ToInt32(precnik) / 3;
                    g.DrawString(Convert.ToString(koren.value), drawFont, stringCetka, parent.X, parent.Y);
                    parent.X = D.X - Convert.ToInt32(precnik) / 2;
                    parent.Y = D.Y - Convert.ToInt32(offsetOdD) - Convert.ToInt32(precnik) / 2;

                    double h = Math.Ceiling(Math.Log(n + 1) / Math.Log(2));

                    double xOffsetDece = Convert.ToInt32(Math.Pow(2, h - 1)) * xOffsetDeceBase;

                    //crtanje ostatka dece
                    _drvo.drawingDrvo(koren, parent, Convert.ToInt32(precnik), Convert.ToInt32(yOffsetDece), Convert.ToInt32(xOffsetDece));
                }
                return;
            }
            if (list == true)
            {

            }
        }
        #region Pomeranje
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            B.X = e.X;
            B.Y = e.Y;

            isMoving = 1;
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //pomeranje
            if (isMoving > 0)
            {
                //B = Old_C;
                //Old_C = C;
                C.X = Control.MousePosition.X - this.Location.X - 8;
                C.Y = Control.MousePosition.Y - this.Location.Y - 31;


                if (C.X < B.X)
                {
                    D.X = D.X - (B.X - C.X);
                }
                else
                {
                    D.X = D.X + (C.X - B.X);
                }


                if (C.Y < B.Y)
                {
                    D.Y = D.Y - (B.Y - C.Y);
                }
                else
                {
                    D.Y = D.Y + (C.Y - B.Y);
                }
                Refresh();
                B = C;
            }
        }
        #endregion
        #region ResponsiveUI
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            _lista = new Lista(CreateGraphics(), this);
            _drvo = new Drvo(CreateGraphics(), this);
            D.X = ClientRectangle.Width / 2 - 125;
            D.Y = ClientRectangle.Height / 2;

            Point A = new Point(0, 60);

            button1.Text = "Kreiraj novo drvo";
            button4.Text = "Kreuraj novu listu";
            button5.Text = "Simuliraj sortiranje";
            button12.Text = "Kreiraj novi stack";

            textBox1.Size = new Size(190, 60);
            textBox1.Enabled = false;
            textBox1.Text = Convert.ToString(zoom);

            timer1.Interval = 17;
            timer1.Start();
        }
        #endregion
        #region Zoom
        private void button2_Click(object sender, EventArgs e)
        {
            zoom += 0.1;
            textBox1.Text = Convert.ToString(zoom);
            Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (zoom < 0.1)
                zoom = 0.1;
            if (zoom != 0.1)
            {
                zoom -= 0.1;
                textBox1.Text = Convert.ToString(zoom);
                Refresh();
            }
        }
        #endregion

        //Novo Drvo
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            try
            {
                _drvo.ucitajDrvoIzBaseFaila();
                tree = true;
                list = false;
                red = false;
                stack = false;
                Refresh();
            }
            catch
            {
            }
        }

        //Nova Lista
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            try
            {
                //_lista.ucitajListuIzBaseFaila();
                tree = true;
                list = false;
                red = false;
                stack = false;
            }
            catch
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isCollapsedFile)
            {
                panel19.Enabled = false;
                panelDropDown.BringToFront();

                panelDropDown.Size = panelDropDown.MaximumSize;
                isCollapsedFile = false;

                pictureBox3.BringToFront();
                pictureBox4.BringToFront();
                pictureBox5.BringToFront();
            }
            else
            {
                panel19.Enabled = true;
                panel19.BringToFront();

                panelDropDown.Size = panelDropDown.MinimumSize;
                isCollapsedFile = true;

                pictureBox3.BringToFront();
                pictureBox4.BringToFront();
                pictureBox5.BringToFront();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isCollapsedSimulate)
            {
                panelDropDown.Enabled = false;
                panel19.BringToFront();

                panel19.Size = panel19.MaximumSize;
                isCollapsedSimulate = false;

                pictureBox3.BringToFront();
                pictureBox4.BringToFront();
                pictureBox5.BringToFront();
            }
            else
            {

                panelDropDown.Enabled = true;
                panel19.BringToFront();

                panel19.Size = panel19.MinimumSize;
                isCollapsedSimulate = true;

                pictureBox3.BringToFront();
                pictureBox4.BringToFront();
                pictureBox5.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isMaximized == true)
            {
                isMaximized = false;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                isMaximized = true;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            if (!isCollapsedFile)
            {
                panel19.Enabled = true;
                panel19.BringToFront();

                panelDropDown.Size = panelDropDown.MinimumSize;
                isCollapsedFile = true;

                pictureBox3.BringToFront();
                pictureBox4.BringToFront();
                pictureBox5.BringToFront();
            }
        }

        private void panelDropDown_MouseLeave(object sender, EventArgs e)
        {
            if (!isCollapsedFile)
            {
                panel19.Enabled = true;
                panel19.BringToFront();

                panelDropDown.Size = panelDropDown.MinimumSize;
                isCollapsedFile = true;

                pictureBox3.BringToFront();
                pictureBox4.BringToFront();
                pictureBox5.BringToFront();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            try
            {
                //_lista.ucitajListuIzBaseFaila();
                tree = false;
                list = false;
                red = false;
                stack = true;
            }
            catch
            {
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Refresh();
            int sleep = 500;
            if(trackBar1.Value == 2)
            {
                sleep = 750;
            }


            if (trackBar1.Value == 1)
            {
                sleep = 1000;
            }


            if (trackBar1.Value == 0)
            {
                sleep = 1250;
            }


            if (trackBar1.Value == 4)
            {
                sleep = 300;
            }


            if (trackBar1.Value == 5)
            {
                sleep = 150;
            }

            double precnik = 50 * zoom;
            double offsetOdD = 150 * zoom;
            double yOffsetDece = 90 * zoom;
            double xOffsetDeceBase = 20 * zoom;



            Point parent = new Point(D.X - Convert.ToInt32(precnik) / 2, D.Y - Convert.ToInt32(offsetOdD) - Convert.ToInt32(precnik) / 2);



            double h = Math.Ceiling(Math.Log(n + 1) / Math.Log(2));
            double xOffsetDece = Convert.ToInt32(Math.Pow(2, h - 1)) * xOffsetDeceBase;
            if (!checkBox1.Checked)
                _drvo.PreOrder(koren, parent, Convert.ToInt32(precnik), Convert.ToInt32(yOffsetDece), Convert.ToInt32(xOffsetDece), sleep);
            else
            {
                //SAFTAM TI MUDA 
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            preOrderAnalizaKeepGoing = true;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Refresh();
            int sleep = 500;
            if (trackBar2.Value == 2)
            {
                sleep = 750;
            }


            if (trackBar2.Value == 1)
            {
                sleep = 1000;
            }


            if (trackBar2.Value == 0)
            {
                sleep = 1250;
            }


            if (trackBar2.Value == 4)
            {
                sleep = 300;
            }


            if (trackBar2.Value == 5)
            {
                sleep = 150;
            }

            double precnik = 50 * zoom;
            double offsetOdD = 150 * zoom;
            double yOffsetDece = 90 * zoom;
            double xOffsetDeceBase = 20 * zoom;



            Point parent = new Point(D.X - Convert.ToInt32(precnik) / 2, D.Y - Convert.ToInt32(offsetOdD) - Convert.ToInt32(precnik) / 2);



            double h = Math.Ceiling(Math.Log(n + 1) / Math.Log(2));
            double xOffsetDece = Convert.ToInt32(Math.Pow(2, h - 1)) * xOffsetDeceBase;
            if (!checkBox1.Checked)
                _drvo.InOrder(koren, parent, Convert.ToInt32(precnik), Convert.ToInt32(yOffsetDece), Convert.ToInt32(xOffsetDece), sleep);
            else
            {
                //SAFTAM TI MUDA 
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Refresh();
            int sleep = 500;
            if (trackBar3.Value == 2)
            {
                sleep = 750;
            }


            if (trackBar3.Value == 1)
            {
                sleep = 1000;
            }


            if (trackBar3.Value == 0)
            {
                sleep = 1250;
            }


            if (trackBar3.Value == 4)
            {
                sleep = 300;
            }


            if (trackBar3.Value == 5)
            {
                sleep = 150;
            }

            double precnik = 50 * zoom;
            double offsetOdD = 150 * zoom;
            double yOffsetDece = 90 * zoom;
            double xOffsetDeceBase = 20 * zoom;



            Point parent = new Point(D.X - Convert.ToInt32(precnik) / 2, D.Y - Convert.ToInt32(offsetOdD) - Convert.ToInt32(precnik) / 2);



            double h = Math.Ceiling(Math.Log(n + 1) / Math.Log(2));
            double xOffsetDece = Convert.ToInt32(Math.Pow(2, h - 1)) * xOffsetDeceBase;
            if (!checkBox1.Checked)
                _drvo.PostOrder(koren, parent, Convert.ToInt32(precnik), Convert.ToInt32(yOffsetDece), Convert.ToInt32(xOffsetDece), sleep);
            else
            {
                //SAFTAM TI MUDA 
            }
        }
    }
}

