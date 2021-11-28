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

namespace test
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        double zoom = 1;
        //drvo, a je precnik cvora, b je offset od centralne tacke D, c1 vertikalni offset dece, c2 horizontalni, c3 je offset njegove detece (eksponencionalno se smanjuje), n je broj elemenata trenutne strukture
        double a = 50, b = 150, c1 = 90, c2 = 110, c3;
        int n = 0;

        //Tacke na osnovu koji se crta, D je centar ekrana oko koga se crta sve, B i C se koristi za pomeranje tacno D pri drag and drop-u misa
        Point B = new Point();
        Point C = new Point();
        Point D = new Point();

        //is moving, koristi se za pomeranje svega sa drag n drop
        int isMoving = 0;
        int?[] arr = new int?[4096];

        //Za sta se trenutno koristi program
        bool tree = false;
        bool list = false;
        bool red = false;
        bool stack = false;

        //drvo

        Node noviCvor(int x)
        {
            Node novi = new Node();
            novi.value = x;
            novi.left = null;
            novi.right = null;

            return novi;
        }
        Node koren = new Node();
        void drawingDrvo(Node root, Point parent, int a, int c1, double c2)
        {
            
            Point W = new Point();
            Graphics g = CreateGraphics();
            Pen olovka = new Pen(Color.Black, Convert.ToInt32(zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(zoom *16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
            if (root.left != null && root.left.value != null && root!= null && root.value !=null)
            {
                W.Y = parent.Y + c1;
                W.X = parent.X - Convert.ToInt32(c2);
                //g.DrawEllipse(olovka, W.X, W.Y, a, a);
                g.FillEllipse(cetka, W.X, W.Y, a, a);
                

                parent.X += a / 2;
                parent.Y += a / 2;
                W.X = parent.X - Convert.ToInt32(c2);
                W.Y = parent.Y + c1;
                g.DrawLine(olovka, parent, W);
                

                //TextBox t = new TextBox();

                parent.X -= a / 2;
                parent.Y -= a / 2;
                W.Y = parent.Y + c1 + a / 8 ;
                W.X = parent.X - Convert.ToInt32(c2) + a / 8;
                g.DrawString(Convert.ToString(root.left.value), drawFont, stringCetka, W);

                W.X = parent.X - Convert.ToInt32(c2);
                W.Y = parent.Y + c1;
                drawingDrvo(root.left, W, a, c1, c2 / 2);
            }
            if (root.right != null && root.right.value != null && root != null && root.value != null)
            {
                W.Y = parent.Y + c1;
                W.X = parent.X + Convert.ToInt32(c2);
               //g.DrawEllipse(olovka, W.X, W.Y, a, a);
                g.FillEllipse(cetka, W.X, W.Y, a, a);
                

                parent.X += a / 2;
                parent.Y += a / 2;
                W.X = parent.X + Convert.ToInt32(c2);
                W.Y = parent.Y + c1;
                g.DrawLine(olovka, parent, W);
                parent.X -= a / 2;
                parent.Y -= a / 2;

                W.Y = parent.Y + c1 + a / 8;
                W.X = parent.X + Convert.ToInt32(c2) + a / 8;
                g.DrawString(Convert.ToString(root.right.value), drawFont, stringCetka, W);

                
                W.X = parent.X + Convert.ToInt32(c2);
                W.Y = parent.Y + c1;
                drawingDrvo(root.right, W, a, c1, c2 / 2);
            }
            return;
        }
        Node generisiDrvoIzNiza(int?[] arr, Node root, int i, int n)
        {
            if (i < n)
            {
                Node temp = new Node();
                temp.value = arr[i];
                root = temp;

                    root.left = generisiDrvoIzNiza(arr, root.left, 2 * i + 1, n);
                    root.right = generisiDrvoIzNiza(arr, root.right, 2 * i + 2, n);
                    return root;

            }
            return root;
        }
        void ucitajDrvoIzBaseFaila()
        {
            try
            {
                StreamReader f = new StreamReader("Drva/trenutnoDrvo.txt");
                int i = 0;
                string temp;
                while (!f.EndOfStream)
                {
                    temp = f.ReadLine();
                    if (temp.Equals(""))
                    {
                        arr[i] = null;
                    }
                    else
                    {
                        arr[i] = Convert.ToInt32(temp);
                    }
                    i++;
                }
                n = i;
            }
            catch
            {
            }
        }
        
        //lista
        Element dodajNaPocetak(Element lista, int? x)
        {
            Element novi = new Element();
            novi.value = x;
            novi.next = lista;
            return novi;
        }

        Element dodajNaKraj(Element lista, int? x)
        {
            Element novi = new Element();
            novi.value = x;

            if (lista == null)
                return dodajNaPocetak(lista, x);

            Element temp = lista;
            while (temp.next != null)
                temp = temp.next;

            temp.next = novi;
            novi.next = null;
            return lista;
        }
        Element lista = new Element();
        void drawingLista(Element lista, Point Parent)
        {
            Point W = new Point();
            Graphics g = CreateGraphics();
            Pen olovka = new Pen(Color.Black, Convert.ToInt32(zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
        }
        void ucitajListuIzBaseFaila()
        {
            try
            {
                
                StreamReader f = new StreamReader("Liste/trenutnaLista.txt");
                string temp;
                while (!f.EndOfStream)
                {
                    temp = f.ReadLine();
                    if (temp.Equals(""))
                    {
                        lista=dodajNaKraj(lista,null);
                    }
                    else
                    {
                        lista =dodajNaKraj(lista,Convert.ToInt32(temp));
                    }
                }
            }
            catch
            {
            }
        }
        
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (tree == true)
            {
                //a je precnik cvora, b offset korena od D, c1 vertikalni offset dece, c2 horizontalni
                a = 50 * zoom;
                b = 150 * zoom;
                c1 = 90 * zoom;
                c2 = 12 * zoom;


                koren = generisiDrvoIzNiza(arr, koren, 0, n);
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
                    parent.X = D.X - Convert.ToInt32(a) / 2;
                    parent.Y = D.Y - Convert.ToInt32(b) - Convert.ToInt32(a) / 2;

                    g.FillEllipse(cetka, parent.X, parent.Y, Convert.ToInt32(a), Convert.ToInt32(a));
                    parent.Y = D.Y - Convert.ToInt32(b) - Convert.ToInt32(a) / 3;
                    parent.X = D.X - Convert.ToInt32(a) / 3;
                    g.DrawString(Convert.ToString(koren.value), drawFont, stringCetka, parent.X, parent.Y);
                    parent.X = D.X - Convert.ToInt32(a) / 2;
                    parent.Y = D.Y - Convert.ToInt32(b) - Convert.ToInt32(a) / 2;

                    double h = Math.Ceiling(Math.Log(n + 1) / Math.Log(2));

                    c3 = Convert.ToInt32(Math.Pow(2, h - 1)) * c2;

                    //crtanje ostatka dece
                    drawingDrvo(koren, parent, Convert.ToInt32(a), Convert.ToInt32(c1), Convert.ToInt32(c3));
                }
                return;
            }
            if (list == true)
            {
                 a = 50 * zoom;
                 b = 200 * zoom;
                 //List<>
            }
        }

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

        private void Form1_Load(object sender, EventArgs e)
        {
            D.X = ClientRectangle.Width / 2 - 125;
            D.Y = ClientRectangle.Height / 2;

            this.BackgroundImage = App.Properties.Resources.gas;

            Point A = new Point(0, 0);
            //gornji tool bar
            listBox1.Location = A;
            listBox1.Size = new Size(ClientRectangle.Width, 30);

            button1.Location = A;

            A.X += 100;
            button4.Location = A;

            //desni tool bar
            A.X = ClientRectangle.Width - 250;
            listBox2.Size = new Size(250, ClientRectangle.Height);
            listBox2.Location = A;

            //zoom
            A.Y += 1;
            button2.Location = A;
            A.X += 30;
            button3.Location = A;
            A.X += 30;
            textBox1.Location = A;
            
            button1.Size = new Size(100, 30);
            button1.Text = "Kreiraj novo drvo";
            button4.Size = new Size(100, 30);
            button4.Text = "Kreuraj novu listu";
            
            textBox1.Size = new Size(190, 60);
            textBox1.Enabled = false;
            textBox1.Text = Convert.ToString(zoom);

            timer1.Interval = 17;
            timer1.Start();
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
        private void Form1_Resize(object sender, EventArgs e)
        {
            Point A = new Point(0, 0);
            //gornji tool bar
            listBox1.Location = A;
            listBox1.Size = new Size(ClientRectangle.Width, 30);

            button1.Location = A;

            A.X += 100;
            button4.Location = A;

            //desni tool bar
            A.X = ClientRectangle.Width - 250;
            listBox2.Size = new Size(250, ClientRectangle.Height+10);
            listBox2.Location = A;

            //zoom
            A.Y += 1;
            button2.Location = A;
            A.X += 30;
            button3.Location = A;
            A.X += 30;
            textBox1.Location = A;
        }

        //Zoom +
        private void button2_Click(object sender, EventArgs e)
        {
                zoom += 0.1;
                textBox1.Text = Convert.ToString(zoom);
                Refresh();
        }

        //Zoom -
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

        //Novo Drvo
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            ucitajDrvoIzBaseFaila();
            tree = true;
            list = false;
            red = false;
            stack = false;
        }

        //Nova Lista
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            ucitajListuIzBaseFaila();
            tree = true;
            list = false;
            red = false;
            stack = false;
        }   
    }
    class Node
    {
        public int? value;
        public Node left;
        public Node right;
    }
    class Element
    {
        public int? value;
        public Element next;
    }
}
   