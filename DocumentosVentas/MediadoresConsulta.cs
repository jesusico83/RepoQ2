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
    public partial class MediadoresConsulta : Form
    {
        public MediadoresConsulta()
        {
            InitializeComponent();
        }
        public string clie_id;
        public string usu_id;
        public string mediador;

        private MediadoresConsultaCtx ctx = new MediadoresConsultaCtx();    
 
        private void MostrarListado()
        {
            this.fdlv1.ClearObjects();
            ctx.SEL(usu_id, clie_id)
            this.fdlv1.DataSource = ctx.personal_lista;
            if (ctx.personal_lista.Count() == 0)
            {
                MessageBox.Show("No hay registros con los filtros seleccionados");
            }
        }
        public void SeleccionarRegistro()
        {
            PERSONAL_CON_Q2Result persona = (PERSONAL_CON_Q2Result)this.fdlv1.SelectedObject;
            if (persona != null)
            {
                pers_id = persona.PERS_ID;
                pers_nombre = persona.PERS_NOMBRE;
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void ClientesConsult_Load(object sender, EventArgs e)
        {            
            this.fdlv1.ClearObjects();
        }

        private void btnClientesCon_Click(object sender, EventArgs e)
        {
            MostrarListado();
        }

        private void btnActaVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }
    }
}
