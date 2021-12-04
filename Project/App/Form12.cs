﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        private int br;
        public Form12(int Br)
        {
            br = Br;
        }
        private void Form12_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton[] btnArr = new System.Windows.Forms.RadioButton[br];
            this.Size=new Size(419,206+21*br);
            for (int i = 0; i < 2 * br; i += 2)
            {
                btnArr[i] = new RadioButton();
                btnArr[i + 1] = new RadioButton();
                btnArr[i].Location = new Point(5, 5 + (i - i / 2) * 21);
                btnArr[i + 1].Location = new Point(ClientRectangle.Width - 5, 5 + (i - i / 2) * 21);
                btnArr[i].Update();
                btnArr[i + 1].Update();
            }
        }
    }
}