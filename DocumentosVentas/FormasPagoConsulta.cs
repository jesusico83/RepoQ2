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
    public partial class FormasPagoConsulta : Form
    {
        public FormasPagoConsulta()
        {
            InitializeComponent();
        }
        
        FormasPagoConsultaCtx ctx = new FormasPagoConsultaCtx();
        // Valores devueltos
        public int codigo;
        public string descripcion;

        private void MostrarListado()
        {
            ctx.FORMAS_PAGO_CON();
            this.fdlv1.DataSource = ctx.formas_pago;
        }

        private void SeleccionarRegistro()
        {
            FORMAS_PAGO_Q2_CONResult forma = (FORMAS_PAGO_Q2_CONResult)fdlv1.SelectedObject;
            if (forma != null)
            {
                this.codigo = forma.FPAGO_ID;
                this.descripcion = forma.FPAGO_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FormasPagoConsulta_Load(object sender, EventArgs e)
        {
            MostrarListado();
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
