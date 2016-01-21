using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quercus_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageList i = new ImageList();
            i.Images.Add("key1", Image.FromFile(@"D:\Quercus 2\Resources\Acta\A 128x128.png"));
            i.Images.Add("key2", Image.FromFile(@"D:\Quercus 2\Resources\Acta\A 128x128.png"));


            
        }
    }
}
