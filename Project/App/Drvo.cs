using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using test;

namespace App
{
    class Drvo
    {
        private Graphics g;
        private Form1 form1;

        public Drvo(Graphics g, Form1 form)
        {
            this.g = g;
            form1 = form;
        }

        private Node noviCvor(int x)
        {
            Node novi = new Node();
            novi.value = x;
            novi.left = null;
            novi.right = null;

            return novi;
        }
        public void drawingDrvo(Node root, Point parent, int a, int c1, double c2)
        {
            Point W = new Point();
            Pen olovka = new Pen(Color.Black, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
            if (root.left != null && root.left.value != null && root != null && root.value != null)
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
                W.Y = parent.Y + c1 + a / 8;
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
        public Node generisiDrvoIzNiza(int?[] arr, Node root, int i, int n)
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
        public void ucitajDrvoIzBaseFaila()
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
                        form1.arr[i] = null;
                    }
                    else
                    {
                        form1.arr[i] = Convert.ToInt32(temp);
                    }
                    i++;
                }
                form1.n = i;
                f.Dispose();
            }
            catch
            {
            }
        }
        public void PreOrder(Node root, Point parent, int a, int c1, double c2)
        {
            int sleep = 1000;

            Point W = new Point();
            Point Y = new Point();
            Point parentA = parent;
            Point parentB = new Point(parent.X, parent.Y+a);
            Point parentC = new Point(parent.X+a, parent.Y+a);
            Point parentD = new Point(parent.X+a, parent.Y);
            
            Pen olovka = new Pen(Color.Green, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);

            System.Threading.Thread.Sleep(sleep);
            g.DrawLine(olovka, parentA, parentB);
            if (root.left != null)
            {
                W.X = parentB.X - Convert.ToInt32(c2);
                W.Y = parentB.Y + c1 - a;
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentB, W);

                PreOrder(root.left, W, a, c1, c2 / 2);

                if (root.right != null)
                {
                    W.X = parentB.X + a - Convert.ToInt32(c2);
                    W.Y = parentB.Y + c1 - a;

                    Y.X = parentB.X + a / 2;
                    Y.Y = parentB.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);

                    W.X = parentC.X - a +Convert.ToInt32(c2);
                    W.Y = parentC.Y + c1 -a;

                    Y.X = parentC.X - a / 2;
                    Y.Y = parentC.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);
                    PreOrder(root.right, W, a, c1, c2 / 2);

                    W.X = parentD.X + Convert.ToInt32(c2);
                    W.Y = parentD.Y + c1;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, parentC);

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentD, parentC);
                }
                else
                {
                    W.X = parentB.X - Convert.ToInt32(c2) + a;
                    W.Y = parentB.Y + c1;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, parentC);
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentC, parentD);
                    return;
                }
            }
            else
            {
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentB, parentC);
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentC, parentD);
                return;

            }
        }
    }
}
