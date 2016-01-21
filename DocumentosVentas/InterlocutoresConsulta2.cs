using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocumentosVentas
{
    public partial class InterlocutoresConsulta2 : Form
    {
        public InterlocutoresConsulta2()
        {
            InitializeComponent();
        }
        public int clie_id;
        public string nombre;

        private void InterlocutoresConsulta2_Load(object sender, EventArgs e)
        {
            InterlocutoresConsultaDBDataContext ctx = new InterlocutoresConsultaDBDataContext();
            var inter = from i in ctx.CLIENTES_INTER
                                   where i.CLIE_ID == clie_id
                                   select i;
            fdlv1.DataSource = inter;            
        }
        private void SeleccionarRegistro()
        {
            CLIENTES_INTER interlocutores = (CLIENTES_INTER)fdlv1.SelectedObject;
            if (interlocutores != null)
            {
                nombre = interlocutores.CLIEI_NOMBRE;
                this.DialogResult = DialogResult.OK;
                this.Close();                
            }
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }
    }
}
