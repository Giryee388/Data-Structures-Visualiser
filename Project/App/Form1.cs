
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
        public bool preOrderAnalizaKeepGoing = false;

        Drvo _drvo;
        Lista _lista;
        Stek _stek;
        Red _red;
        Graf _graf;
        Export _export;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);

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
        public bool tree = false;
        public bool list = false;
        public bool queue = false;
        public bool stack = false;
        public bool graph = false;

        public Element lista = new Element();
        public Element stek = new Element();
        public Element red = new Element();
        Node koren = new Node();
        public ListaCvorova graf = new ListaCvorova();
        int brojCvorovaGrafa;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (tree == true)
            {
                panel27.Visible = true;

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
                return;
            }
            else
            {
                panel27.Visible = false;
            }
            if (list == true)
            {
                //Funkcije za listu panel . vidljive = tacno

                double precnikKorena = 50 * zoom;
                double duzinaSekcijeElementa = 90 * zoom;
                double visinaSekcijeElementa = 35 * zoom;
                double razdaljinaOdProslog = 70 * zoom;
                double xOffsetOdD = 400 * zoom;

                Graphics g = e.Graphics;
                Font drawFont = new Font("Arial", Convert.ToInt32(zoom * 16));
                SolidBrush cetka = new SolidBrush(Color.Black);
                SolidBrush stringCetka = new SolidBrush(Color.White);
                Pen olovka = new Pen(Color.DarkGray, Convert.ToInt32(zoom * 6));

                Point parent = new Point();
                parent.X = D.X - Convert.ToInt32(xOffsetOdD);
                parent.Y = D.Y;

                g.DrawEllipse(olovka, parent.X, parent.Y, Convert.ToInt32(precnikKorena), Convert.ToInt32(precnikKorena));
                g.FillEllipse(cetka, parent.X, parent.Y, Convert.ToInt32(precnikKorena), Convert.ToInt32(precnikKorena));

                parent.X = D.X - Convert.ToInt32(xOffsetOdD);
                parent.Y = D.Y;
                _lista.drawingLista(lista, parent, duzinaSekcijeElementa, visinaSekcijeElementa, razdaljinaOdProslog, precnikKorena);

                
            }
            if (stack == true) {
                double razdaljina = 10 * zoom;
                double visinaElementa = 50 * zoom;
                double duzinaElementa = 150 * zoom;
                double xOffsetOdD = 400 * zoom;

                Graphics g = e.Graphics;
                Font drawFont = new Font("Arial", Convert.ToInt32(zoom * 16));
                SolidBrush cetka = new SolidBrush(Color.Black);
                SolidBrush stringCetka = new SolidBrush(Color.White);
                Pen olovka = new Pen(Color.DarkGray, Convert.ToInt32(zoom * 6));

                Point parent = new Point();
                parent.X = D.X - Convert.ToInt32(xOffsetOdD);
                parent.Y = D.Y;

                g.DrawLine(olovka, parent.X - Convert.ToInt32(razdaljina+olovka.Width/2), parent.Y + Convert.ToInt32(razdaljina + visinaElementa), parent.X + Convert.ToInt32(duzinaElementa + razdaljina+olovka.Width/2), parent.Y + Convert.ToInt32(razdaljina + visinaElementa));
                _stek.drawingStack(stek,parent,duzinaElementa, visinaElementa, razdaljina);
                }
            if (graph)
            {
                double stranica = 225 * zoom;
                double polOpisanog = (stranica / 2) / (Math.Cos(Math.PI / brojCvorovaGrafa));
                double precnikCvora = 50 * zoom;

                Graphics g = e.Graphics;
                Font drawFont = new Font("Arial", Convert.ToInt32(zoom * 16));
                SolidBrush cetka = new SolidBrush(Color.Black);
                SolidBrush stringCetka = new SolidBrush(Color.White);
                Pen olovka = new Pen(Color.DarkGray, Convert.ToInt32(zoom * 6));

                _graf.drawingGraf(graf, stranica, polOpisanog, precnikCvora, D, olovka, drawFont, cetka, stringCetka);

            }
            if (queue == true)
            {
                double razdaljina = 25 * zoom;
                double visinaElementa = 50 * zoom;
                double duzinaElementa = 150 * zoom;
                double xOffsetOdD = 400 * zoom;

                Graphics g = e.Graphics;
                Font drawFont = new Font("Arial", Convert.ToInt32(zoom * 16));
                SolidBrush cetka = new SolidBrush(Color.Black);
                SolidBrush stringCetka = new SolidBrush(Color.White);
                Pen olovka = new Pen(Color.DarkGray, Convert.ToInt32(zoom * 6));

                Point parent = new Point();
                parent.X = D.X - Convert.ToInt32(xOffsetOdD);
                parent.Y = D.Y;
                _red.drawingRed(red, parent, duzinaElementa, visinaElementa, razdaljina);
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
        #region Load
        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            _lista = new Lista(CreateGraphics(), this);
            _drvo = new Drvo(CreateGraphics(), this);
            _stek = new Stek(CreateGraphics(), this);
            _red = new Red(CreateGraphics(), this);
            _graf = new Graf(CreateGraphics(), this);
            _export = new Export();

            D.X = ClientRectangle.Width / 2 - 125;
            D.Y = ClientRectangle.Height / 2;

            Point A = new Point(0, 60);

            timer1.Interval = 17;
            timer1.Start();
        }
        #endregion
        #region Zoom
        /*private void button2_Click(object sender, EventArgs e)
        {
            zoom += 0.1;
            //textBox1.Text = Convert.ToString(zoom);
            Refresh();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (zoom < 0.1)
                zoom = 0.1;
            if (zoom != 0.1)
            {
                zoom -= 0.1;
                //textBox1.Text = Convert.ToString(zoom);
                Refresh();
            }
        }
        */
        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                zoom += 0.2;
                //textBox1.Text = Convert.ToString(zoom);
                Refresh();
            }
            if (e.Delta < 0)
            {
                if (zoom < 0.2)
                    zoom = 0.2;
                if (zoom != 0.2)
                {
                    zoom -= 0.2;
                    //textBox1.Text = Convert.ToString(zoom);
                    Refresh();
                }
            }
        }

        #endregion
        #region Dugmici Gornji Menubar
        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _export.ExportAsCodeDrvo();
        }

        private void ListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            //try
            //{
            if (File.Exists("da.txt"))
            {
                File.Delete("da.txt");
                _lista.ucitajListuIzBaseFaila();
                tree = false;
                list = true;
                queue = false;
                stack = false;
                Refresh();
            }
            //}
            //catch
            //{
            //}
        }

        private void stackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            //try
            //{
            if (File.Exists("da.txt"))
            {
                File.Delete("da.txt");
                _stek.ucitajStekIzBaseFaila();
                tree = false;
                list = false;
                queue = false;
                stack = true;
                Refresh();
            }
            //}
            //catch
            //{
            //}
        }

        private void queueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            //try
            //{
            if (File.Exists("da.txt"))
            {
                File.Delete("da.txt");
                _red.ucitajRedIzBaseFaila();
                tree = false;
                list = false;
                queue = true;
                stack = false;
                Refresh();
            }
            //}
            //catch
            //{
            //}
        }

        private void binaryTreeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            try
            {
                if (File.Exists("da.txt"))
                {
                    File.Delete("da.txt");
                    _drvo.ucitajDrvoIzBaseFaila();
                    tree = true;
                    queue = false;
                    stack = false;
                    list = false;
                    Refresh();
                }
            }
            catch
            {
            }
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            //try
            //{
            if (File.Exists("da.txt"))
            {
                File.Delete("da.txt");
                brojCvorovaGrafa = _graf.ucitajGrafIzBaseFaila();
                tree = false;
                list = false;
                queue = false;
                stack = false;
                graph = true;
                Refresh();
            }
            //}
            //catch
            //{
            //}
        }

        private void sortingAlgorithamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        

        #endregion
        #region Funkcije za drvo
        private void button13_Click(object sender, EventArgs e)
        {
            Refresh();
            int sleep = 500;
            if (trackBar1.Value == 2)
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
        private void button15_Click(object sender, EventArgs e)
        {
            Refresh();
            int sleep = 500;
            if (trackBar4.Value == 2)
            {
                sleep = 750;
            }


            if (trackBar4.Value == 1)
            {
                sleep = 1000;
            }


            if (trackBar4.Value == 0)
            {
                sleep = 1250;
            }


            if (trackBar4.Value == 4)
            {
                sleep = 300;
            }


            if (trackBar4.Value == 5)
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
                _drvo.brojListova(koren, parent, Convert.ToInt32(precnik), Convert.ToInt32(yOffsetDece), Convert.ToInt32(xOffsetDece), sleep, Convert.ToInt32(75 * zoom));
            else
            {
                //SAFTAM TI MUDA 
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.ShowDialog();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.ShowDialog();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.ShowDialog();
        }
        #endregion

        



    }
}

