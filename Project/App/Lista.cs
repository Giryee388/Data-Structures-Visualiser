using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using test;

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
            novi.next = lista;
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
        public void drawingLista(Element lista, Point Parent)
        {
            Point W = new Point();
            Pen olovka = new Pen(Color.Black, Convert.ToInt32(form1.zoom * 6));
            Font drawFont = new Font("Arial", Convert.ToInt32(form1.zoom * 16));
            SolidBrush cetka = new SolidBrush(Color.Black);
            SolidBrush stringCetka = new SolidBrush(Color.White);


        }
        public void ucitajListuIzBaseFaila(Element lista)
        {
            try
            {

                StreamReader f = new StreamReader("Liste/trenutnaLista.txt");
                string temp;
                while (!f.EndOfStream)
                {
                    temp = f.ReadLine();
                    lista = dodajNaKraj(lista, Convert.ToInt32(temp));
                }
            }
            catch
            {
            }
        }     
    }
}
