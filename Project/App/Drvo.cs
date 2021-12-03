using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using test;
using System.Media;

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
        public void PreOrder(Node root, Point parent, int a, int c1, double c2, int sleep)
        {
            

            Point W = new Point();
            Point Y = new Point();
            Point parentA = parent;
            Point parentB = new Point(parent.X, parent.Y+a);
            Point parentC = new Point(parent.X+a, parent.Y+a);
            Point parentD = new Point(parent.X+a, parent.Y);
            



            Pen olovka = new Pen(Color.Green, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Red);
            SolidBrush stringCetka = new SolidBrush(Color.White);




            System.Threading.Thread.Sleep(sleep);
            W.X = parentA.X;
            W.Y = parentA.Y + a / 2;
            g.DrawLine(olovka, parentA, W);
            SystemSounds.Hand.Play();
            g.FillEllipse(cetka, parentA.X - Convert.ToInt32(form1.zoom * 15) / 2, parentA.Y + a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));
            if (root.left != null)
            {


                W.X = parentB.X - Convert.ToInt32(c2);
                W.Y = parentB.Y + c1 - a;

                Y.X = parentB.X;
                Y.Y = parentB.Y - a / 2;
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, Y, W);



                PreOrder(root.left, W, a, c1, c2 / 2, sleep);



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



                    PreOrder(root.right, W, a, c1, c2 / 2, sleep);



                    W.X = parentD.X + Convert.ToInt32(c2);
                    W.Y = parentD.Y + c1;
                    Y.X = parentC.X;
                    Y.Y = parentC.Y - a / 2;
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentD, Y);
                }
                else
                {
                    

                    W.X = parentA.X - Convert.ToInt32(c2) + a;
                    W.Y = parentA.Y + c1;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, parentC);
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentC, parentD);
                    return;
                }
            }
            else
            {
                W.X = parentB.X;
                W.Y = parentB.Y - a / 2;

                g.DrawLine(olovka, W, parentB);

                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentB, parentC);
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentC, parentD);
                return;

            }
        }
        //NE ZNAM KAKO OVO DA NAPRAVIM, TREBA ASINC DA BUDE A JA TO NE UMEM
        //GLUP SAM RETARDIRAN I SAMO NE ZNAM DA URADIM CELU NOC SAM POKUSAVAO
        //izvinite me

        /*
        public void PreOrderAnaliza(Node root, Point parent, int a, int c1, double c2, int sleep)
        {


            Point W = new Point();
            Point Y = new Point();
            Point parentA = parent;
            Point parentB = new Point(parent.X, parent.Y + a);
            Point parentC = new Point(parent.X + a, parent.Y + a);
            Point parentD = new Point(parent.X + a, parent.Y);

         * 
         * 
         * 
            Pen olovka = new Pen(Color.Green, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Red);
            SolidBrush stringCetka = new SolidBrush(Color.White);

         * 
         * 
         *
            System.Threading.Thread.Sleep(sleep);
            W.X = parentA.X;
            W.Y = parentA.Y + a / 2;
            g.DrawLine(olovka, parentA, W);
            SystemSounds.Hand.Play();
            g.FillEllipse(cetka, parentA.X - Convert.ToInt32(form1.zoom * 15) / 2, parentA.Y + a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));
            if (root.left != null)
            {
         * 
         * 
         * 
                W.X = parentB.X - Convert.ToInt32(c2);
                W.Y = parentB.Y + c1 - a;

                Y.X = parentB.X;
                Y.Y = parentB.Y - a / 2;
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, Y, W);

         * 
         * 
         * 
         * 
                PreOrderAnaliza(root.left, W, a, c1, c2 / 2, sleep);

         * 
         * 
         * 
         * 
                if (root.right != null)
                {
                    W.X = parentB.X + a - Convert.ToInt32(c2);
                    W.Y = parentB.Y + c1 - a;

                    Y.X = parentB.X + a / 2;
                    Y.Y = parentB.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);

                    W.X = parentC.X - a + Convert.ToInt32(c2);
                    W.Y = parentC.Y + c1 - a;

                    Y.X = parentC.X - a / 2;
                    Y.Y = parentC.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);

         * 
         * 
         * 
                    PreOrderAnaliza(root.right, W, a, c1, c2 / 2, sleep);

         * 
         * 
         * 
                    W.X = parentD.X + Convert.ToInt32(c2);
                    W.Y = parentD.Y + c1;
                    Y.X = parentC.X;
                    Y.Y = parentC.Y - a / 2;
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentD, Y);
                }
                else
                {

         * 
         * 

                    W.X = parentA.X - Convert.ToInt32(c2) + a;
                    W.Y = parentA.Y + c1;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, parentC);
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentC, parentD);
                    return;
         * 
         * 
         * 
         * 
                }
            }
            else
            {
                W.X = parentB.X;
                W.Y = parentB.Y - a / 2;

                g.DrawLine(olovka, W, parentB);

                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentB, parentC);
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentC, parentD);
                return;

            }
        }
         */
        public void InOrder(Node root, Point parent, int a, int c1, double c2, int sleep)
        {




            Point W = new Point();
            Point Y = new Point();
            Point parentA = parent;
            Point parentB = new Point(parent.X, parent.Y + a);
            Point parentC = new Point(parent.X + a, parent.Y + a);
            Point parentD = new Point(parent.X + a, parent.Y);




            Pen olovka = new Pen(Color.Green, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Red);
            SolidBrush stringCetka = new SolidBrush(Color.White);



            System.Threading.Thread.Sleep(sleep);
            W.X = parentA.X;
            W.Y = parentA.Y + a / 2;
            g.DrawLine(olovka, parentA, W);
            


            if (root.left != null)
            {


                W.X = parentB.X - Convert.ToInt32(c2);
                W.Y = parentB.Y + c1 - a;

                Y.X = parentB.X;
                Y.Y = parentB.Y - a / 2;
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, Y, W);

                
                    
                    
                InOrder(root.left, W, a, c1, c2 / 2, sleep);




                if (root.right != null)
                {
                    W.X = parentB.X + a - Convert.ToInt32(c2);
                    W.Y = parentB.Y + c1 - a;

                    Y.X = parentB.X + a / 2;
                    Y.Y = parentB.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);
                    SystemSounds.Hand.Play();
                    g.FillEllipse(cetka, parentB.X + a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, parentC.Y - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));

                    W.X = parentC.X - a + Convert.ToInt32(c2);
                    W.Y = parentC.Y + c1 - a;

                    Y.X = parentC.X - a / 2;
                    Y.Y = parentC.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);



                    InOrder(root.right, W, a, c1, c2 / 2, sleep);




                    W.X = parentD.X + Convert.ToInt32(c2);
                    W.Y = parentD.Y + c1;
                    Y.X = parentC.X;
                    Y.Y = parentC.Y - a / 2;
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentD, Y);
                }
                else
                {


                    W.X = parentA.X - Convert.ToInt32(c2) + a;
                    W.Y = parentA.Y + c1;

                    Y.X = parentC.X - a / 2;
                    Y.Y = parentC.Y;



                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);



                    SystemSounds.Hand.Play();
                    g.FillEllipse(cetka, parentB.X + a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, parentC.Y - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentC, Y);



                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentC, parentD);

                    return;
                }
            }
            else
            {
                W.X = parentB.X;
                W.Y = parentB.Y - a / 2;

                g.DrawLine(olovka, W, parentB);


                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentB, parentC);
                SystemSounds.Hand.Play();
                g.FillEllipse(cetka, parentB.X + a/2 - Convert.ToInt32(form1.zoom * 15) / 2, parentC.Y - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));
                
                
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentC, parentD);
                
                
                return;
            }
        }
        public void PostOrder(Node root, Point parent, int a, int c1, double c2, int sleep)
        {




            Point W = new Point();
            Point Y = new Point();
            Point parentA = parent;
            Point parentB = new Point(parent.X, parent.Y + a);
            Point parentC = new Point(parent.X + a, parent.Y + a);
            Point parentD = new Point(parent.X + a, parent.Y);




            Pen olovka = new Pen(Color.Green, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Red);
            SolidBrush stringCetka = new SolidBrush(Color.White);



            System.Threading.Thread.Sleep(sleep);
            W.X = parentA.X;
            W.Y = parentA.Y + a / 2;
            g.DrawLine(olovka, parentA, W);



            if (root.left != null)
            {


                W.X = parentB.X - Convert.ToInt32(c2);
                W.Y = parentB.Y + c1 - a;

                Y.X = parentB.X;
                Y.Y = parentB.Y - a / 2;
                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, Y, W);




                PostOrder(root.left, W, a, c1, c2 / 2, sleep);




                if (root.right != null)
                {
                    W.X = parentB.X + a - Convert.ToInt32(c2);
                    W.Y = parentB.Y + c1 - a;

                    Y.X = parentB.X + a / 2;
                    Y.Y = parentB.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);
                    

                    W.X = parentC.X - a + Convert.ToInt32(c2);
                    W.Y = parentC.Y + c1 - a;

                    Y.X = parentC.X - a / 2;
                    Y.Y = parentC.Y;

                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);



                    PostOrder(root.right, W, a, c1, c2 / 2, sleep);




                    W.X = parentD.X + Convert.ToInt32(c2);
                    W.Y = parentD.Y + c1;
                    Y.X = parentC.X;
                    Y.Y = parentC.Y - a / 2;
                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);


                    SystemSounds.Hand.Play();
                    g.FillEllipse(cetka, parentC.X - Convert.ToInt32(form1.zoom * 15) / 2, parentC.Y - a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));


                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentD, Y);
                }
                else
                {


                    W.X = parentA.X - Convert.ToInt32(c2) + a;
                    W.Y = parentA.Y + c1;

                    Y.X = parentC.X - a / 2;
                    Y.Y = parentC.Y;



                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, W, Y);



                    System.Threading.Thread.Sleep(sleep);
                    g.DrawLine(olovka, parentC, Y);


                    
                    System.Threading.Thread.Sleep(sleep);
                    
                    
                    SystemSounds.Hand.Play();
                    g.FillEllipse(cetka, parentC.X - Convert.ToInt32(form1.zoom * 15) / 2, parentC.Y - a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));
                    
                    
                    g.DrawLine(olovka, parentC, parentD);

                    return;
                }
            }
            else
            {
                W.X = parentB.X;
                W.Y = parentB.Y - a / 2;

                g.DrawLine(olovka, W, parentB);


                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentB, parentC);


                System.Threading.Thread.Sleep(sleep);
                g.DrawLine(olovka, parentC, parentD);
                SystemSounds.Hand.Play();
                g.FillEllipse(cetka, parentC.X - Convert.ToInt32(form1.zoom * 15) / 2, parentC.Y - a / 2 - Convert.ToInt32(form1.zoom * 15) / 2, Convert.ToInt32(form1.zoom * 15), Convert.ToInt32(form1.zoom * 15));

                return;
            }
        }
        List<Point> Lines = new List<Point>();
        public void brojListova(Node root, Point parent, int a, int c1, double c2, int sleep, int b)
        {

            Point parentA = new Point(parent.X + (a - b) / 2, parent.Y + (a - b) / 2);

            Pen olovka = new Pen(Color.Yellow, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Red);
            SolidBrush stringCetka = new SolidBrush(Color.White);

            
            g.DrawEllipse(olovka, parentA.X, parentA.Y, b, b);
            System.Threading.Thread.Sleep(sleep);
            Lines.Add(parentA);
            SystemSounds.Hand.Play();

            if (root.left == null && root.right == null)
            {
                olovka.Color = Color.Green;
                g.DrawEllipse(olovka, parentA.X, parentA.Y, b, b);
                olovka.Color = Color.Yellow;
            }

            if (root.left != null)
            {
                parent.X -= Convert.ToInt32(c2);
                parent.Y += c1;
                brojListova(root.left, parent, a, c1, c2/2, sleep, b);
            }
            if (root.right != null)
            {
                parent.X += 2*   Convert.ToInt32(c2);
                brojListova(root.right, parent, a, c1, c2/2, sleep, b);
            }
        }
    }
}
