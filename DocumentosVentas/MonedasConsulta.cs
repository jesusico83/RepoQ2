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
    public partial class MonedasConsulta : Form
    {
        public MonedasConsulta()
        {
            InitializeComponent();
        }
        // Contexto
        MonedasConsultaCtx ctx = new MonedasConsultaCtx();

        // parámetros
       
        // Valores devueltos
        public string codigo;
        public string descripcion;

        private void MostrarListado()
        {
            ctx.MONEDAS_CON();
            this.fdlv1.DataSource = ctx.monedas;
        }

        private void SeleccionarRegistro()
        {
            MONEDAS_Q2_CONResult moneda = (MONEDAS_Q2_CONResult)fdlv1.SelectedObject;
            if (moneda != null)
            {
                this.codigo = moneda.MONEDA_ID;
                this.descripcion = moneda.MONEDA_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void MonedasConsulta_Load(object sender, EventArgs e)
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
