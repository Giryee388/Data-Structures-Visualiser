using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace App
{
    public class ListaCvorova
    {
        public int? vrednost { get; set; }
        public ListaCvorova sledeci { get; set; }
        public ListaVeza veze { get; set; }
    }
}
