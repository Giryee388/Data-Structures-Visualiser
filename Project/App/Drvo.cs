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
    }
}
