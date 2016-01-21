using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilidades
{
    public partial class FitosoilHeaderFormatStyle : BrightIdeasSoftware.HeaderFormatStyle
    {
        public FitosoilHeaderFormatStyle()
        {
            InitializeComponent();

            this.Normal.Font = new Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
        }

        public FitosoilHeaderFormatStyle(Font font)
        {
            InitializeComponent();

            this.Normal.Font = font;
        }

    }
}