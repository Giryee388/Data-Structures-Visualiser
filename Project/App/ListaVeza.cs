using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class ListaVeza
    {
        public ListaCvorova veza { get; set; }
        public int? value { get; set; }
        //public ListaCvorova izvor { get; set; }
        public ListaVeza sledeci { get; set; }
    }
}
