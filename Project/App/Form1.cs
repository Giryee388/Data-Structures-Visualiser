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
        //bool levo = true;
        double zoom = 1;
        double a = 50, b = 150, c1 = 90, c2 = 110, c3;
        Point B = new Point();
        Point C = new Point();
        Point D = new Point();
        int isMoving = 0, n=0;
        int?[] arr = new int?[4096];
        bool tree = false;
        bool list = false;
        bool queue = false;
        bool stack = false;
        /*
        void test(Node cvor)
        {
            if (cvor == null)
                return;

            listBox3.Items.Add(cvor.value);
            test(cvor.left);
            test(cvor.right);
        }
         */
        Node noviCvor(int x)
        {
            Node novi = new Node();
            novi.value = x;
            novi.left = null;
            novi.right = null;

            return novi;
        }
        void Preorder(Node root, Point parent, int a, int c1, double c2)
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
                Preorder(root.left, W, a, c1, c2 / 2);
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
                Preorder(root.right, W, a, c1, c2 / 2);
            }
            return;
        }
/*        void levelOrder(Node cvor)
        {
            if (cvor == null)
                return;
   
            Queue<Node> q;
            q.push(cvor);

            while (!q.empty())
            {
                Cvor* temp = q.front();
                q.pop();
                printf("%d ", temp->vrednost);
                if (temp->levo != NULL)
                    q.push(temp->levo);
                if (temp->desno != NULL)
                    q.push(temp->desno);
            }
        }
 */
        Node insertLevelOrder(int?[] arr, Node root, int i, int n)
        {
            if (i < n)
            {
                Node temp = new Node();
                temp.value = arr[i];
                root = temp;

                    root.left = insertLevelOrder(arr, root.left, 2 * i + 1, n);
                    root.right = insertLevelOrder(arr, root.right, 2 * i + 2, n);
                    return root;

            }
            return root;

            
        }
        void ucitajDrvoIzBaseFaila()
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

        void ucitajListuIzBaseFaila()
        {
            StreamReader f = new StreamReader("Liste/trenutnaLista.txt");
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
        }
        Node koren = new Node();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (tree == true)
            {
                //a je precnik cvora, b offset korena od D, c1 vertikalni offset dece, c2 horizontalni
                a = 50 * zoom;
                b = 150 * zoom;
                c1 = 90 * zoom;
                c2 = 12 * zoom;


                koren = insertLevelOrder(arr, koren, 0, n);
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
                    Preorder(koren, parent, Convert.ToInt32(a), Convert.ToInt32(c1), Convert.ToInt32(c3));
                }
                return;
            }
            if (list == true)
            {
                 a = 50 * zoom;
                 b = 200 * zoom;
                 List<>
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
            this.BackgroundImage = Properties.Resources.gas;
            D.X = ClientRectangle.Width / 2 - 125;
            D.Y = ClientRectangle.Height / 2;

            timer1.Interval = 17;
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point A = new Point(0, 0);
            listBox1.Location = A;
            listBox1.Size = new Size(ClientRectangle.Width, 30);
            button1.Location = A;
            button1.Size = new Size(100, 30);
            button1.Text = "Kreiraj novo drvo";
            A.X += 100;
            button4.Location = A;
            button4.Size = new Size(100, 30);
            button4.Text = "Kreiraj novu listu";
            A.X = ClientRectangle.Width - 250;
            listBox2.Location = A;
            listBox2.Size = new Size(250, ClientRectangle.Height);
            A.Y += 1;
            button2.Location = A;
            A.X += 30;
            button3.Location = A;
            A.X += 30;
            textBox1.Location = A;
            textBox1.Size = new Size(190, 60);
            textBox1.Enabled = false;
            textBox1.Text = Convert.ToString(zoom);


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

        private void button2_Click(object sender, EventArgs e)
        {
            
                zoom += 0.1;
                Refresh();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (zoom < 0.1)
                zoom = 0.1;
            if (zoom != 0.1)
            {
                zoom -= 0.1;
                Refresh();
            }   

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            ucitajDrvoIzBaseFaila();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            while (Application.OpenForms.Count > 1)
            {
            }
            //ucitajDrvoIzBaseFaila();
        }
    }
    class Node
    {
        public int? value;
        public Node left;
        public Node right;
    }
}
    