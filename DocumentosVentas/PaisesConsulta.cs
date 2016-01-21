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
    public partial class PaisesConsulta : Form
    {
        public PaisesConsulta()
        {
            InitializeComponent();
        }

        private PaisesConsultaCtx ctx = new PaisesConsultaCtx();
        // Parámetros del proc. almacenado
        
        // Valores devueltos por la consulta
        public string codigo;
        public string descripcion;

        private void MostrarListado()
        {
            ctx.PAISES_CON();
            this.fdlv1.DataSource = ctx.paises;
        }


        private void SeleccionarRegistro()
        {
            PAISES_Q2_CONResult pais = (PAISES_Q2_CONResult)fdlv1.SelectedObject;

            if (pais != null)
            {
                this.codigo = pais.PAIS_ID;
                this.descripcion = pais.PAIS_DESCRIPCION;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void PaisesConsulta_Load(object sender, EventArgs e)
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
