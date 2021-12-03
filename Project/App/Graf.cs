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
        
        public void ucitajGrafIzBaseFaila()
        {
            try
            {
                StreamReader f = new StreamReader("Graf/trenutniGraf.txt");
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

    }
}
