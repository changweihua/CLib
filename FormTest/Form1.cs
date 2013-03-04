using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CLib.CImage;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = @"D:\123.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(@"D:\123.jpg");
            this.pictureBox2.Image = bm.AtomizationImage();
        }
    }
}
