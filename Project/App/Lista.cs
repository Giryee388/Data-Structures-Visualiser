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
    class Lista
    {
        private Graphics g;
        private Form1 form1;

        public Lista(Graphics g, Form1 form)
        {
            this.g = g;
            form1 = form;
        }

        private Element dodajNaPocetak(Element lista, int? x)
        {
            Element novi = new Element();
            novi.value = x;
            novi.next = lista.next;
            return novi;
        }
        private Element dodajNaKraj(Element lista, int? x)
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
        public void drawingLista(Element lista, Point Parent, double duzinaSekcijeElementa, double visinaSekcijeElementa, double razdaljinaOdProslog, double precnikKorena)
        {
            Point W = new Point();
            Pen olovka = new Pen(Color.DarkGray, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
            if (lista.next.value != null)
            {
                W.Y = Parent.Y + Convert.ToInt32(precnikKorena)/2;
                W.X = Parent.X + Convert.ToInt32(precnikKorena)/2;
                g.DrawLine(olovka, W.X, W.Y, W.X + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(precnikKorena) / 2, W.Y);

                W.X = Parent.X + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(precnikKorena);
                W.Y = Parent.Y + Convert.ToInt32((precnikKorena - visinaSekcijeElementa)/2);

                g.FillRectangle(cetka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));
                g.DrawRectangle(olovka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));

                W.Y += Convert.ToInt32(visinaSekcijeElementa / 5);
                W.X += Convert.ToInt32(visinaSekcijeElementa / 5);

                g.DrawString(Convert.ToString(lista.next.value), drawFont, stringCetka, W.X, W.Y);

                W.X = Parent.X + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(precnikKorena);
                W.Y = Parent.Y + Convert.ToInt32((precnikKorena - visinaSekcijeElementa) / 2);
                W.X += Convert.ToInt32(duzinaSekcijeElementa);
                g.FillRectangle(cetka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));
                g.DrawRectangle(olovka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));


                Parent.X += Convert.ToInt32(precnikKorena) + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(duzinaSekcijeElementa);
                Parent.Y += Convert.ToInt32((precnikKorena - visinaSekcijeElementa) / 2);
                drawingListaBackend(lista, Parent, duzinaSekcijeElementa, visinaSekcijeElementa, razdaljinaOdProslog);
            }
        }
        public void drawingListaBackend(Element lista, Point Parent, double duzinaSekcijeElementa, double visinaSekcijeElementa, double razdaljinaOdProslog)
        {
            Point W = new Point();
            Pen olovka = new Pen(Color.DarkGray, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);
            if (lista.next.next == null)
            {
                return;
            }
            W.Y = Parent.Y + Convert.ToInt32(visinaSekcijeElementa) / 2;
            W.X = Parent.X + Convert.ToInt32(duzinaSekcijeElementa) / 2;
            g.DrawLine(olovka, W.X, W.Y, W.X + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(duzinaSekcijeElementa), W.Y);

            W.X = Parent.X + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(duzinaSekcijeElementa);
            W.Y = Parent.Y;

            g.FillRectangle(cetka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));
            g.DrawRectangle(olovka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));

            W.Y += Convert.ToInt32(visinaSekcijeElementa / 5);
            W.X += Convert.ToInt32(visinaSekcijeElementa / 5);

            g.DrawString(Convert.ToString(lista.next.next.value), drawFont, stringCetka, W.X, W.Y);

            W.X = Parent.X + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(duzinaSekcijeElementa);
            W.Y = Parent.Y;
            W.X += Convert.ToInt32(duzinaSekcijeElementa);
            g.FillRectangle(cetka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));
            g.DrawRectangle(olovka, W.X, W.Y, Convert.ToInt32(duzinaSekcijeElementa), Convert.ToInt32(visinaSekcijeElementa));
            Parent.X += Convert.ToInt32(duzinaSekcijeElementa) + Convert.ToInt32(razdaljinaOdProslog) + Convert.ToInt32(razdaljinaOdProslog);

            drawingListaBackend(lista.next, Parent, duzinaSekcijeElementa, visinaSekcijeElementa, razdaljinaOdProslog);
        }
        public void ucitajListuIzBaseFaila()
        {
            StreamReader f = new StreamReader("Liste/trenutnaLista.txt");
            Element lista = new Element();
            lista.next = null;
            string temp;
            while (!f.EndOfStream)
            {
                temp = f.ReadLine();
                form1.lista = dodajNaKraj(lista, Convert.ToInt32(temp));
            }
            
        }
    }
}
