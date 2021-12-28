using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace App
{
    class Export
    {
        public void ExportAsCodeDrvo()
        {
            Stream f;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "C source file (*.c)|*.c|Text files(*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((f = saveFileDialog1.OpenFile()) != null)
                {
                    int i = 0;
                    string s = "#include <stdio.h> @#include <stdlib.h>@@typedef struct Cvor    @{@    int vrednost;@    struct Cvor *levo;@    struct Cvor *desno;@} Cvor;@@Cvor* noviCvor(int x)@{@    Cvor* novi = malloc(sizeof(Cvor));@    novi->vrednost = x;@    novi->levo = NULL;@    novi->desno = NULL;@@    return novi;@}@@int main()@{@";
                    int[] arr = new int[2048];
                    try
                    {
                        StreamReader fs = new StreamReader("Drva/trenutnoDrvo.txt");


                        string temp;
                        while (!fs.EndOfStream)
                        {
                            temp = fs.ReadLine();
                            arr[i] = Convert.ToInt32(temp);
                            i++;
                        }
                        fs.Dispose();
                    }
                    catch
                    {
                    }
                    //i = 0;
                    string osnova = "    root";
                    string levo = "->levo";
                    string desno = "->desno";
                    string final1 = " = noviCvor(";
                    string final2 = "); @";
                    long binC = 1;
                    int intLeng;
                    for (int k = 0; k < i; k++)
                    {
                        if (binC == 1)
                        {
                            s += "    struct Cvor *root = noviCvor(" + arr[k] + ");@";
                            binC = addBit(binC);
                            continue;
                        }
                        intLeng = Convert.ToString(binC).Count();
                        s += osnova;
                        for (int j = intLeng - 2; j >= 0; j--)
                        {
                            if (binC / Math.Pow(10, j) % 10 == 1)
                            {
                                s += desno;
                            }
                            else
                            {
                                s += levo;
                            }
                        }
                        s += final1;
                        s += arr[k];
                        s += final2;
                        binC = addBit(binC);
                    }
                    s += "    return 0;@}";
                    s = s.Replace("@", Environment.NewLine);
                    byte[] bytes = Encoding.ASCII.GetBytes(s);
                    f.Write(bytes, 0, s.Length);
                }
            }
        }
        private long addBit(long broj)
        {
            string temp = Convert.ToString(Convert.ToInt32(Convert.ToString(broj), 2), 10);
            long tempInt = Convert.ToInt64(temp) + 1;
            return Convert.ToInt64(Convert.ToString(tempInt, 2));

        }
    }
}
