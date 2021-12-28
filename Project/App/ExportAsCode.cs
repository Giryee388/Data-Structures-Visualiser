using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace App
{
    public partial class ExportAsCode : Form
    {
        public ExportAsCode()
        {
            InitializeComponent();
        }



        private void ExportAsCode_Load(object sender, EventArgs e)
        {
            Stream f;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((f = saveFileDialog1.OpenFile()) != null)
                {
                    
                    //FileStream fs = File.Create(saveFileDialog1.FileName);
                    /*
                        #include <stdio.h>
                        #include <stdlib.h>

                        typedef struct Cvor {

                            int vrednost;
                            struct Cvor *levo;
                            struct Cvor *desno;

                        } Cvor;           */
                    //StreamWriter f = new StreamWriter(saveFileDialog1.FileName);
                    //f.Write("#include <stdio.h> #include <stdlib.h> typedef struct Cvor {    int vrednost;    struct Cvor *levo;    struct Cvor *desno;} Cvor;");
                }
            }
        }
    }
}
