using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programas
{
    public partial class Consulta : Form
    {
        public Object DataSource { get; set; }

        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            // Comprobar Excepciones
            this.fdlvConsulta.DataSource = DataSource;
        }


    }
}
