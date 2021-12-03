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
    class Stek
    {
        private Graphics g;
        private Form1 form1;

        public Stek(Graphics g, Form1 form)
        {
            this.g = g;
            form1 = form;
        }
        private Element dodajNaPocetak(Element Stek, int? x)
        {
            Element novi = new Element();
            novi.value = x;
            novi.next = Stek.next;
            return novi;
        }
        private Element dodajNaKraj(Element Stek, int? x)
        {
            Element novi = new Element();
            novi.value = x;

            if (Stek == null)
                return dodajNaPocetak(Stek, x);

            Element temp = Stek;
            while (temp.next != null)
                temp = temp.next;

            temp.next = novi;
            novi.next = null;
            return Stek;
        }
        public void drawingStack(Element Stek, Point Parent,double duzinaElementa, double visinaElementa,double razdaljina){
            Point W = new Point();
            Pen ovloka = new Pen(Color.DarkGray, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
            if (Stek.next.next == null)
            {
                return;
            }
                W.X = Parent.X;
                W.Y = Parent.Y;
                g.DrawLine(ovloka, W.X+ Convert.ToInt32(duzinaElementa/2 + razdaljina), W.Y, W.X + Convert.ToInt32(duzinaElementa/2 + razdaljina), W.Y - Convert.ToInt32(duzinaElementa+2*razdaljina));
                W.X = Parent.X;
                g.DrawLine(ovloka, W.X - Convert.ToInt32(duzinaElementa / 2 + razdaljina), W.Y, W.X - Convert.ToInt32(duzinaElementa / 2 + razdaljina), W.Y - Convert.ToInt32(duzinaElementa+2*razdaljina));
                g.DrawRectangle(ovloka, W.X, W.Y, Convert.ToInt32(duzinaElementa), Convert.ToInt32(visinaElementa));
                g.DrawString(Convert.ToString(Stek.next.next.value), drawFont, stringCetka, W.X, W.Y);
                Parent.Y += Convert.ToInt32(2 * razdaljina);
                drawingStack(Stek, Parent, duzinaElementa, visinaElementa, razdaljina);
        }
        public void ucitajStekIzBaseFaila()
        {
            StreamReader f = new StreamReader("Stekovi/trenutniStek.txt");
            Element lista = new Element();
            lista.next = null;
            string temp;
            while (!f.EndOfStream)
            {
                temp = f.ReadLine();
                //form1.Stek = dodajNaKraj(Stek, Convert.ToInt32(temp));
            }

        }
    }
}
