using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using test;

namespace App
{
    class Graf
    {
        private Graphics g;
        private Form1 form1;
        private ListaVeza veze;

        public Graf(Graphics g, Form1 form)
        {
            this.g = g;
            form1 = form;
        }
        
        public int ucitajGrafIzBaseFaila()
        {
            try
            {
                StreamReader f = new StreamReader("Grafovi/trenutniGraf/cvorovi.txt");
                int i = 0;
                string temp;
                while (!f.EndOfStream)
                {
                    temp = f.ReadLine();
                    if (temp.Equals(""))
                    {
                        form1.graf.vrednost = null;
                    }
                    else
                    {
                        form1.graf.vrednost = Convert.ToInt32(temp);
                        
                        if (File.Exists("Grafovi/trenutniGraf/" + Convert.ToInt32(temp) + ".txt"))
                        {
                            StreamReader v = new StreamReader("Grafovi/trenutniGraf/" + Convert.ToInt32(temp) + ".txt");

                            while (!v.EndOfStream)
                            {
                                form1.graf.veze.veza = dajMiPokazivac(Convert.ToInt32(v.ReadLine()), form1.graf);
                                form1.graf.veze = form1.graf.veze.sledeci;
                            }
                            v.Dispose();
                        }
                        form1.graf = form1.graf.sledeci;
                        form1.graf.index = i;
                    }
                    i++;
                }
                form1.n = i;
                f.Dispose();
                return i;
            }
            catch
            {
                return 0;
            }
        }
        public ListaCvorova dajMiPokazivac(int imeCvora, ListaCvorova cvorovi)
        {
            while(cvorovi!=null)
            {
                if (cvorovi.vrednost == imeCvora)
                {
                    return cvorovi;
                }
                cvorovi = cvorovi.sledeci;
            }
            return cvorovi;
        }
        public void drawingGraf(ListaCvorova graf, double n, double polOpisanog, double precnikCvora, Point centar, Pen olovka, Font drawFont, SolidBrush cetka, SolidBrush stringCetka)
        {

            //Point[] nizCvorova = new Point[Convert.ToInt32(n)];
            ListaCvorova tempGraf = graf;
            for (int i = 1; i < n+1; i++)
            {
                tempGraf.koordinate = new Point(Convert.ToInt32(centar.X + polOpisanog * Math.Cos(2 * Math.PI * i / n)), Convert.ToInt32(centar.Y + polOpisanog * Math.Sin(2 * Math.PI * i / n)));
            }
            
            for (int i = 0; i < n; i++)
            {
                //ListaVeza tempVeze = graf.veze;
                while(tempGraf.veze!=null)
                {
                    g.DrawLine(olovka, tempGraf.koordinate, tempGraf.veze.veza.koordinate);
                    tempGraf.veze = tempGraf.veze.sledeci;
                }
                tempGraf = tempGraf.sledeci;
            }
            tempGraf = graf;
            for (int i = 0; i < n; i++)
            {
                g.FillEllipse(cetka, Convert.ToInt32(tempGraf.koordinate.X - precnikCvora / 2), Convert.ToInt32(tempGraf.koordinate.Y - precnikCvora / 2), Convert.ToInt32(precnikCvora), Convert.ToInt32(precnikCvora));
                g.DrawEllipse(olovka, Convert.ToInt32(tempGraf.koordinate.X - precnikCvora / 2), Convert.ToInt32(tempGraf.koordinate.Y - precnikCvora / 2), Convert.ToInt32(precnikCvora), Convert.ToInt32(precnikCvora));
                g.DrawString(graf.vrednost.ToString(), drawFont, stringCetka, Convert.ToInt32(tempGraf.koordinate.X - precnikCvora / 2 - 5), Convert.ToInt32(tempGraf.koordinate.Y - precnikCvora / 2 - 5));
                tempGraf = tempGraf.sledeci;
            }
        }

    }
}
