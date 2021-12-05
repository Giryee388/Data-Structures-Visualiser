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
    class Red
    {
        private Graphics g;
        private Form1 form1;

        public Red(Graphics g, Form1 form)
        {
            this.g = g;
            form1 = form;
        }
        private Element dodajNaPocetak(Element Red, int? x)
        {
            Element novi = new Element();
            novi.value = x;
            novi.next = Red.next;
            return novi;
        }
        private Element dodajNaKraj(Element Red, int? x)
        {
            Element novi = new Element();
            novi.value = x;

            if (Red == null)
                return dodajNaPocetak(Red, x);

            Element temp = Red;
            while (temp.next != null)
                temp = temp.next;

            temp.next = novi;
            novi.next = null;
            return Red;
        }
        public void drawingRed(Element Red, Point Parent, double duzinaElementa, double visinaElementa,double razdaljina){
            Point W = new Point();
            Pen ovloka = new Pen(Color.DarkGray, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
            if (Red.next == null)
            {
                return;
            }
                W.X = Parent.X;
                W.Y = Parent.Y;
                g.DrawRectangle(ovloka, W.X, W.Y, Convert.ToInt32(duzinaElementa), Convert.ToInt32(visinaElementa));

                W.X = Parent.X + Convert.ToInt32(razdaljina / 5);
                W.Y = Parent.Y + Convert.ToInt32(razdaljina / 5);
                g.DrawString(Convert.ToString(Red.next.value), drawFont, stringCetka, W.X, W.Y);
              
                W.X = Parent.X - Convert.ToInt32(razdaljina);
                W.Y = Parent.Y - Convert.ToInt32(razdaljina);
                g.DrawLine(ovloka, W.X, W.Y, W.X + Convert.ToInt32(4 * razdaljina + duzinaElementa), W.Y);

                W.X = Parent.X - Convert.ToInt32(razdaljina);
                W.Y = Parent.Y + Convert.ToInt32(razdaljina+visinaElementa);
                g.DrawLine(ovloka, W.X, W.Y, W.X + Convert.ToInt32(4 * razdaljina + duzinaElementa), W.Y);

                if (Red.next.next == null)
                {
                    W.X = Parent.X + Convert.ToInt32(duzinaElementa+razdaljina / 5);
                    W.Y = Parent.Y + Convert.ToInt32(razdaljina / 5);
                    g.DrawString("NULL", drawFont, stringCetka, W.X, W.Y);

                }
                else {
                    W.X = Parent.X + Convert.ToInt32(duzinaElementa);
                    W.Y = Parent.Y + Convert.ToInt32(visinaElementa/2);
                    g.DrawLine(ovloka, W.X, W.Y, W.X + Convert.ToInt32(duzinaElementa), W.Y);

                    W.X = Parent.X + Convert.ToInt32(3 * razdaljina + duzinaElementa);
                    W.Y = Parent.Y - Convert.ToInt32(razdaljina);
                    g.DrawLine(ovloka, W.X, W.Y, W.X + Convert.ToInt32(duzinaElementa - razdaljina), W.Y);

                    W.X = Parent.X + Convert.ToInt32(3 * razdaljina + duzinaElementa);
                    W.Y = Parent.Y + Convert.ToInt32(razdaljina + visinaElementa);
                    g.DrawLine(ovloka, W.X, W.Y, W.X + Convert.ToInt32(duzinaElementa - razdaljina), W.Y);
                }

                Parent.X += Convert.ToInt32(2 * duzinaElementa);
                drawingRed(Red.next, Parent, duzinaElementa, visinaElementa, razdaljina);
        }
        public void ucitajRedIzBaseFaila()
        {
            StreamReader f = new StreamReader("Redovi/TrenutniRed.txt");
            Element red = new Element();
            red.next = null;
            string temp;
            while (!f.EndOfStream)
            {
                temp = f.ReadLine();
                form1.red = dodajNaKraj(red, Convert.ToInt32(temp));
            }

        }
    }
}
