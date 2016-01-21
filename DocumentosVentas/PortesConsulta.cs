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
    public partial class PortesConsulta : Form
    {
        public PortesConsulta()
        {
            InitializeComponent();
        }
        private PortesConsultaCtx ctx = new PortesConsultaCtx();
        // Parámetros del proc. almacenado
        public string usu_id;

        // Valores devueltos por la consulta
        public string codigo;
        public string descripcion;

        private void MostrarListado()
        {
            ctx.TIPOS_PORTE_CON(usu_id);
            this.fdlv1.DataSource = ctx.tipos_porte;
        }

        private void PortesConsulta_Load(object sender, EventArgs e)
        {
            MostrarListado();
        }
        private void SeleccionarRegistro()
        {
            TIPOS_PORTE_CONResult tipo = (TIPOS_PORTE_CONResult)fdlv1.SelectedObject;
            
            if (tipo != null)
            {
                this.codigo = tipo.TIPORT_ID;
                this.descripcion = tipo.TIPORT_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void fdlv1_DoubleClick(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }

        private void btnActaVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
